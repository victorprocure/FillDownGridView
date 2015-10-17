//-----------------------------------------------------------------------
// <copyright file="FillDownDataGridView.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownDataGridViewControl
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// Extension of the DataGridView to allow an Excel like fill down
    /// </summary>
    public partial class FillDownDataGridView : DataGridView
    {
        /// <summary>
        /// The constraint boundary
        /// </summary>
        private Rectangle constraintBoundary;

        /// <summary>
        /// The default selection back color
        /// </summary>
        private Color defaultSelectionBackColor;

        /// <summary>
        /// The default selection fore color
        /// </summary>
        private Color defaultSelectionForeColor;

        /// <summary>
        /// The fill down rectangle
        /// </summary>
        private Rectangle fillDownRectangle;

        /// <summary>
        /// The visible fill down rectangle
        /// </summary>
        private Rectangle visibleFillDownRectangle;

        /// <summary>
        /// Initializes a new instance of the <see cref="FillDownDataGridView"/> class.
        /// </summary>
        public FillDownDataGridView()
        {
            this.InitializeComponent();

            this.defaultSelectionBackColor = this.DefaultCellStyle.SelectionBackColor;
            this.defaultSelectionForeColor = this.DefaultCellStyle.SelectionForeColor;
        }

        /// <summary>
        /// Called when [begin fill down].
        /// </summary>
        protected virtual void OnBeginFillDown()
        {
            if (this.BeginFillDown != null)
            {
                this.BeginFillDown.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [end fill down].
        /// </summary>
        protected virtual void OnEndFillDown()
        {
            if (this.EndFillDown != null)
            {
                this.EndFillDown.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [hit fill down constraint].
        /// </summary>
        protected virtual void OnHitFillDownConstraint()
        {
            if (this.HitFillDownConstraint != null)
            {
                this.HitFillDownConstraint.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentException">If e is null get out, shouldn't ever happen</exception>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} is null", nameof(e)));
            }

            base.OnPaint(e);
            if (this.fillingDown)
            {
                using (var borderPen = new Pen(this.FillDownBorderColor, 1))
                using (var parentBorderPen = new Pen(this.FillDownParentBorderColor, 2))
                {
                    e.Graphics.DrawRectangle(borderPen, this.visibleFillDownRectangle);
                    e.Graphics.DrawRectangle(parentBorderPen, this.GetCellDisplayRectangle(this.parentCell.ColumnIndex, this.parentCell.RowIndex, false));
                }
            }
        }

        /// <summary>
        /// Determines whether [is valid cell] [the specified column index].
        /// </summary>
        /// <param name="columnIndex">Index of the column.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns>true if this is a valid cell, i.e not a header cell</returns>
        private static bool IsValidCell(int columnIndex, int rowIndex)
        {
            return columnIndex >= 0 && rowIndex >= 0;
        }

        /// <summary>
        /// Builds the constraint.
        /// </summary>
        /// <param name="cell">The cell.</param>
        private void BuildConstraint(DataGridViewCell cell)
        {
            if (IsValidCell(cell.ColumnIndex, cell.RowIndex))
            {
                var displayedCell = GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, false);
                var constraintIndicator = displayedCell;

                // default constraint to bottom right
                constraintIndicator.Size = new Size(this.constraint.Width, this.constraint.Height);

                switch (this.FillDownAnchor)
                {
                    case FillDownAnchorStyle.BottomRight:
                        constraintIndicator.X = displayedCell.Right - constraintIndicator.Width;
                        constraintIndicator.Y = displayedCell.Bottom - constraintIndicator.Height;
                        break;

                    case FillDownAnchorStyle.BottomLeft:
                        constraintIndicator.X = displayedCell.Left;
                        constraintIndicator.Y = displayedCell.Bottom - constraintIndicator.Height;
                        break;

                    case FillDownAnchorStyle.TopLeft:
                        constraintIndicator.X = displayedCell.Left;
                        constraintIndicator.Y = displayedCell.Top;
                        break;

                    case FillDownAnchorStyle.TopRight:
                        constraintIndicator.X = displayedCell.Right - constraintIndicator.Width;
                        constraintIndicator.Y = displayedCell.Top;
                        break;
                }

                this.constraintBoundary = constraintIndicator;
            }
        }

        /// <summary>
        /// Select all the cells within the fill down rectangle
        /// </summary>
        private void CheckSelection()
        {
            // Glitch in how rectangles are calculated causes the -+ 1 to be needed here...
            var firstHit = this.HitTest(this.visibleFillDownRectangle.Left + 1, this.visibleFillDownRectangle.Top + 1);
            var lastHit = this.HitTest(this.visibleFillDownRectangle.Right - 1, this.visibleFillDownRectangle.Bottom - 1);

            var firstColumn = firstHit.ColumnIndex;
            var firstRow = firstHit.RowIndex;

            var lastColumn = lastHit.ColumnIndex;
            var lastRow = lastHit.RowIndex;

            this.ClearSelection();

            for (int c = firstColumn; c <= lastColumn; c++)
            {
                for (int r = firstRow; r <= lastRow; r++)
                {
                    if (this.IsValidCellForFillDown(c, r))
                    {
                        this[c, r].Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// Draws the fill down rectangle.
        /// </summary>
        /// <param name="columnIndex">Index of the column.</param>
        /// <param name="rowIndex">Index of the row.</param>
        private void DrawFillDownRectangle(int columnIndex, int rowIndex)
        {
            if (this.IsValidCellForFillDown(columnIndex, rowIndex))
            {
                this[columnIndex, rowIndex].Selected = true;

                var cellDisplay = this.GetCellDisplayRectangle(columnIndex, rowIndex, false);
                this.fillDownRectangle = this.GetCellDisplayRectangle(this.parentCell.ColumnIndex, this.parentCell.RowIndex, false);

                int width, height, x, y;

                if (!(columnIndex == this.parentCell.ColumnIndex && rowIndex == this.parentCell.RowIndex))
                {
                    if (cellDisplay.X > this.fillDownRectangle.X)
                    {
                        width = cellDisplay.X - this.fillDownRectangle.X + cellDisplay.Width;
                        x = this.fillDownRectangle.X;
                    }
                    else
                    {
                        width = this.fillDownRectangle.X - cellDisplay.X + this.fillDownRectangle.Width;
                        x = cellDisplay.X;
                    }

                    if (cellDisplay.Y > this.fillDownRectangle.Y)
                    {
                        height = cellDisplay.Y - this.fillDownRectangle.Y + cellDisplay.Height;
                        y = this.fillDownRectangle.Y;
                    }
                    else
                    {
                        height = this.fillDownRectangle.Y - cellDisplay.Y + this.fillDownRectangle.Height;
                        y = cellDisplay.Y;
                    }
                }
                else
                {
                    width = this.fillDownRectangle.Width;
                    height = this.fillDownRectangle.Height;
                    x = this.fillDownRectangle.X;
                    y = this.fillDownRectangle.Y;
                }

                this.visibleFillDownRectangle = new Rectangle(x, y, width, height);
            }
        }

        /// <summary>
        /// Fills down data grid view cell mouse down.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void FillDownDataGridViewCellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.fillingDown && (e.Button | this.FillDownInitiateButton) == this.FillDownInitiateButton)
            {
                if (this.IsMouseInConstraint())
                {
                    this.fillingDown = true;
                    this.parentCell = this[e.ColumnIndex, e.RowIndex];

                    this.EndEdit();

                    this.OnBeginFillDown();

                    if (!this.ShowSelectionFillDown)
                    {
                        this.DefaultCellStyle.SelectionBackColor = this.DefaultCellStyle.BackColor;
                        this.DefaultCellStyle.SelectionForeColor = this.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }

        /// <summary>
        /// Fills down data grid view cell mouse enter.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void FillDownDataGridViewCellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.fillingDown)
            {
                if (IsValidCell(e.ColumnIndex, e.RowIndex))
                {
                    this.BuildConstraint(this[e.ColumnIndex, e.RowIndex]);
                }
            }
            else
            {
                this.Invalidate();
            }
        }

        /// <summary>
        /// Fills down data grid view cell mouse move.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void FillDownDataGridViewCellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.fillingDown)
            {
                if (this.IsMouseInConstraint())
                {
                    this.OnHitFillDownConstraint();
                    this.Cursor = this.FillDownCursor;
                }
                else
                {
                    this.Cursor = this.Parent.Cursor;
                }
            }
            else
            {
                this.DrawFillDownRectangle(e.ColumnIndex, e.RowIndex);
                this.CheckSelection();
            }
        }

        /// <summary>
        /// Fills down data grid view cell mouse up.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataGridViewCellMouseEventArgs"/> instance containing the event data.</param>
        private void FillDownDataGridViewCellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.fillingDown)
            {
                this.fillingDown = false;
                this.FillDownValues();
                this.Invalidate();
                this.OnEndFillDown();

                this.DefaultCellStyle.SelectionForeColor = this.defaultSelectionForeColor;
                this.DefaultCellStyle.SelectionBackColor = this.defaultSelectionBackColor;
            }
        }

        /// <summary>
        /// Fills down values.
        /// </summary>
        private void FillDownValues()
        {
            foreach (DataGridViewCell cell in this.SelectedCells)
            {
                // Ignore parent
                if (!(cell.ColumnIndex == this.parentCell.ColumnIndex && cell.RowIndex == this.parentCell.RowIndex))
                {
                    cell.Value = this.parentCell.Value;
                }
            }
        }

        /// <summary>
        /// Determines whether [is mouse in constraint].
        /// </summary>
        /// <returns>true if the mouse is in the constraint</returns>
        private bool IsMouseInConstraint()
        {
            var mousePosition = this.PointToClient(Cursor.Position);

            if (this.constraintBoundary.Contains(mousePosition))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is valid cell for fill down] [the specified column index].
        /// </summary>
        /// <param name="columnIndex">Index of the column.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns>True if it is a valid cell for fill down</returns>
        private bool IsValidCellForFillDown(int columnIndex, int rowIndex)
        {
            if (IsValidCell(columnIndex, rowIndex))
            {
                if (!this[columnIndex, rowIndex].ReadOnly)
                {
                    if ((!this.FillDownLockColumns && !this.FillDownLockRows)
                    || (this.FillDownLockColumns && columnIndex == this.parentCell.ColumnIndex)
                    || (this.FillDownLockRows && rowIndex == this.parentCell.RowIndex))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}