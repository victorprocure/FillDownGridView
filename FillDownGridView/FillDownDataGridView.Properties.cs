//-----------------------------------------------------------------------
// <copyright file="FillDownDataGridView.Properties.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownDataGridViewControl
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// All user controlled properties for the fill down control
    /// </summary>
    public partial class FillDownDataGridView
    {
        /// <summary>
        /// Gets or sets a value indicating whether [allow fill down].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow fill down]; otherwise, <c>false</c>.
        /// </value>
        [Description("When false this is a DataGridView"), Category("Design")]
        public bool AllowFillDown { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [column lock].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [column lock]; otherwise, <c>false</c>.
        /// </value>
        [Description("Allow filldown to change adjacent columns"), Category("Design")]
        public bool FillDownLockColumns { get; set; }

        /// <summary>
        /// Gets or sets the constraint.
        /// </summary>
        /// <value>
        /// The constraint.
        /// </value>
        [Description("Where is the drag anchor for filling down"), Category("Design")]
        public FillDownAnchorStyle FillDownAnchor { get; set; }

        /// <summary>
        /// Gets or sets the color of the fill down border.
        /// </summary>
        /// <value>
        /// The color of the fill down border.
        /// </value>
        [Description("Fill Down Border Color"), Category("Design")]
        public Color FillDownBorderColor { get; set; }

        /// <summary>
        /// Gets or sets the fill down cursor.
        /// </summary>
        /// <value>
        /// The fill down cursor.
        /// </value>
        [Description("Cursor to show when filling down"), Category("Design")]
        public Cursor FillDownCursor { get; set; }

        /// <summary>
        /// Gets or sets the fill down initiate button.
        /// </summary>
        /// <value>
        /// The fill down initiate button.
        /// </value>
        [Description("Mouse button to initiate the drag for fill down"), Category("Design")]
        public MouseButtons FillDownInitiateButton { get; set; }

        /// <summary>
        /// Gets or sets the color of the fill down parent border.
        /// </summary>
        /// <value>
        /// The color of the fill down parent border.
        /// </value>
        [Description("Fill down Parent Border Color"), Category("Design")]
        public Color FillDownParentBorderColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [row lock].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [row lock]; otherwise, <c>false</c>.
        /// </value>
        [Description("Allow fill down the change adjacent rows"), Category("Design")]
        public bool FillDownLockRows { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show selection fill down].
        /// </summary>
        /// <value>
        /// <c>true</c> if [show selection fill down]; otherwise, <c>false</c>.
        /// </value>
        [Description("Show selection while filling down"), Category("Design")]
        public bool ShowSelectionFillDown { get; set; }
    }
}