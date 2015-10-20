//-----------------------------------------------------------------------
// <copyright file="FillDownDataGridView.Designer.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownDataGridViewControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Contains all the design time values needed for this control
    /// </summary>
    public partial class FillDownDataGridView
    {
        /// <summary>
        /// The components
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Indicate whether we are currently filling down
        /// </summary>
        private bool fillingDown = false;

        /// <summary>
        /// The parent cell
        /// </summary>
        private DataGridViewCell parentCell;

        /// <summary>
        /// Occurs when [begin fill down].
        /// </summary>
        public event EventHandler<EventArgs> BeginFillDown;

        /// <summary>
        /// Occurs when [end fill down].
        /// </summary>
        public event EventHandler<EventArgs> EndFillDown;

        /// <summary>
        /// Occurs when [hit fill down constraint].
        /// </summary>
        public event EventHandler<EventArgs> HitFillDownConstraint;

        /// <summary>
        /// Different locations the constraint box can be located
        /// </summary>
        public enum FillDownAnchorStyle
        {
            /// <summary>
            /// The top left
            /// </summary>
            TopLeft,

            /// <summary>
            /// The top right
            /// </summary>
            TopRight,

            /// <summary>
            /// The bottom left
            /// </summary>
            BottomLeft,

            /// <summary>
            /// The bottom right
            /// </summary>
            BottomRight
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing 
                && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Fills down data grid view mouse move.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void FillDownDataGridViewMouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = this.Parent.Cursor;
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();

            this.AllowFillDown = true;
            this.FillDownLockColumns = true;
            this.FillDownAnchor = FillDownAnchorStyle.BottomRight;
            this.FillDownBorderColor = Color.Red;
            this.FillDownCursor = Cursors.Cross;
            this.FillDownInitiateButton = MouseButtons.Right;
            this.FillDownParentBorderColor = Color.Blue;
            this.FillDownLockRows = false;
            this.ShowSelectionFillDown = false;

            this.CellMouseDown += this.FillDownDataGridViewCellMouseDown;
            this.CellMouseEnter += this.FillDownDataGridViewCellMouseEnter;
            this.CellMouseUp += this.FillDownDataGridViewCellMouseUp;
            this.CellMouseMove += this.FillDownDataGridViewCellMouseMove;
            this.MouseMove += this.FillDownDataGridViewMouseMove;
        }
    }
}
