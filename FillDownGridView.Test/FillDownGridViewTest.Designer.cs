//-----------------------------------------------------------------------
// <copyright file="FillDownGridViewTest.Designer.cs" company="Procure Development">
//     Copyright (c) Procure Development. All rights reserved.
// </copyright>
// <author>Victor Procure</author>
//-----------------------------------------------------------------------
namespace FillDownGridViewTest
{
    using FillDownDataGridViewControl;

    /// <summary>
    /// Designer values for fill down grid test
    /// </summary>
    public partial class FillDownGridViewTest
    {
        /// <summary>
        /// The column1
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;

        /// <summary>
        /// The column2
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;

        /// <summary>
        /// The column3
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;

        /// <summary>
        /// The column4
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column4;

        /// <summary>
        /// The column5
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column5;

        /// <summary>
        /// The column6
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column6;

        /// <summary>
        /// The column7
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column7;

        /// <summary>
        /// The column8
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn column8;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The data grid view1
        /// </summary>
        private FillDownDataGridView dataGridView1;

        /// <summary>
        /// The label1
        /// </summary>
        private System.Windows.Forms.Label label1;

        /// <summary>
        /// The label2
        /// </summary>
        private System.Windows.Forms.Label label2;

        /// <summary>
        /// The label3
        /// </summary>
        private System.Windows.Forms.Label label3;

        /// <summary>
        /// The label4
        /// </summary>
        private System.Windows.Forms.Label label4;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing 
                && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new FillDownDataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5,
            this.column6,
            this.column7,
            this.column8});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(260, 237);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.FillDownLockColumns = false;
            this.dataGridView1.ShowSelectionFillDown = true;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mouse Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cell Constraint:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // Column1
            // 
            this.column1.HeaderText = "Column1";
            this.column1.Name = "Column1";
            // 
            // Column2
            // 
            this.column2.HeaderText = "Column2";
            this.column2.Name = "Column2";
            // 
            // Column3
            // 
            this.column3.HeaderText = "Column3";
            this.column3.Name = "Column3";
            // 
            // Column4
            // 
            this.column4.HeaderText = "Column4";
            this.column4.Name = "Column4";
            // 
            // Column5
            // 
            this.column5.HeaderText = "Column5";
            this.column5.Name = "Column5";
            // 
            // Column6
            // 
            this.column6.HeaderText = "Column6";
            this.column6.Name = "Column6";
            // 
            // Column7
            // 
            this.column7.HeaderText = "Column7";
            this.column7.Name = "Column7";
            // 
            // Column8
            // 
            this.column8.HeaderText = "Column8";
            this.column8.Name = "Column8";
            // 
            // FillDownGridViewTest
            // 
            this.MouseMove += FillDownGridViewTestMouseMove;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 337);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FillDownGridViewTest";
            this.Text = "FillDownGridViewTest";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}