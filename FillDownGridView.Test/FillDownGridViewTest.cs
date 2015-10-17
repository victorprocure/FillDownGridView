//-----------------------------------------------------------------------
// <copyright file="FillDownGridViewTest.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownGridViewTest
{
    using System.Windows.Forms;

    /// <summary>
    /// Testing form for data grid view
    /// </summary>
    public partial class FillDownGridViewTest : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FillDownGridViewTest"/> class.
        /// </summary>
        public FillDownGridViewTest()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Fills down grid view test mouse move.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void FillDownGridViewTestMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.label3.Text = $"X: {Cursor.Position.X}, Y: {Cursor.Position.Y}";
        }
    }
}