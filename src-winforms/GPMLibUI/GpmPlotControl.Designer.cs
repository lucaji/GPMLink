
namespace GPMLib.UI.Winforms {
    partial class GpmPlotControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PlotTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ReadingsPlot = new ScottPlot.FormsPlot();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.GradientFillCheckBox = new System.Windows.Forms.CheckBox();
            this.PlotRangeSelectionCheckBox = new System.Windows.Forms.CheckBox();
            this.PlotAutoResizeCheckBox = new System.Windows.Forms.CheckBox();
            this.PlotTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlotTableLayoutPanel
            // 
            this.PlotTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlotTableLayoutPanel.ColumnCount = 1;
            this.PlotTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlotTableLayoutPanel.Controls.Add(this.label5, 0, 2);
            this.PlotTableLayoutPanel.Controls.Add(this.label4, 0, 0);
            this.PlotTableLayoutPanel.Controls.Add(this.ReadingsPlot, 0, 1);
            this.PlotTableLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.PlotTableLayoutPanel.ForeColor = System.Drawing.Color.White;
            this.PlotTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PlotTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.PlotTableLayoutPanel.Name = "PlotTableLayoutPanel";
            this.PlotTableLayoutPanel.RowCount = 4;
            this.PlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.PlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.PlotTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.PlotTableLayoutPanel.Size = new System.Drawing.Size(981, 580);
            this.PlotTableLayoutPanel.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(0, 507);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(981, 23);
            this.label5.TabIndex = 38;
            this.label5.Text = "PLOT SETTINGS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Font = new System.Drawing.Font("Bahnschrift Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(0, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(981, 23);
            this.label4.TabIndex = 37;
            this.label4.Text = "INTEGRATOR PLOT";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadingsPlot
            // 
            this.ReadingsPlot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadingsPlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ReadingsPlot.BackColor = System.Drawing.Color.Black;
            this.ReadingsPlot.Location = new System.Drawing.Point(8, 34);
            this.ReadingsPlot.Margin = new System.Windows.Forms.Padding(8);
            this.ReadingsPlot.Name = "ReadingsPlot";
            this.ReadingsPlot.Size = new System.Drawing.Size(965, 462);
            this.ReadingsPlot.TabIndex = 24;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.GradientFillCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.PlotRangeSelectionCheckBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.PlotAutoResizeCheckBox, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 536);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(969, 38);
            this.tableLayoutPanel2.TabIndex = 39;
            // 
            // GradientFillCheckBox
            // 
            this.GradientFillCheckBox.AutoSize = true;
            this.GradientFillCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradientFillCheckBox.Location = new System.Drawing.Point(329, 6);
            this.GradientFillCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.GradientFillCheckBox.Name = "GradientFillCheckBox";
            this.GradientFillCheckBox.Size = new System.Drawing.Size(138, 23);
            this.GradientFillCheckBox.TabIndex = 2;
            this.GradientFillCheckBox.Text = "GRADIENT FILL";
            this.GradientFillCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlotRangeSelectionCheckBox
            // 
            this.PlotRangeSelectionCheckBox.AutoSize = true;
            this.PlotRangeSelectionCheckBox.Enabled = false;
            this.PlotRangeSelectionCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotRangeSelectionCheckBox.Location = new System.Drawing.Point(652, 6);
            this.PlotRangeSelectionCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.PlotRangeSelectionCheckBox.Name = "PlotRangeSelectionCheckBox";
            this.PlotRangeSelectionCheckBox.Size = new System.Drawing.Size(165, 23);
            this.PlotRangeSelectionCheckBox.TabIndex = 1;
            this.PlotRangeSelectionCheckBox.Text = "RANGE SELECTION";
            this.PlotRangeSelectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // PlotAutoResizeCheckBox
            // 
            this.PlotAutoResizeCheckBox.AutoSize = true;
            this.PlotAutoResizeCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlotAutoResizeCheckBox.Location = new System.Drawing.Point(6, 6);
            this.PlotAutoResizeCheckBox.Margin = new System.Windows.Forms.Padding(6);
            this.PlotAutoResizeCheckBox.Name = "PlotAutoResizeCheckBox";
            this.PlotAutoResizeCheckBox.Size = new System.Drawing.Size(189, 23);
            this.PlotAutoResizeCheckBox.TabIndex = 0;
            this.PlotAutoResizeCheckBox.Text = "AUTO FIT GRAPH DATA";
            this.PlotAutoResizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // GpmPlotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.PlotTableLayoutPanel);
            this.Font = new System.Drawing.Font("Bahnschrift", 15.75F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GpmPlotControl";
            this.Size = new System.Drawing.Size(981, 580);
            this.Load += new System.EventHandler(this.GpmPlot_Load);
            this.PlotTableLayoutPanel.ResumeLayout(false);
            this.PlotTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PlotTableLayoutPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private ScottPlot.FormsPlot ReadingsPlot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox PlotRangeSelectionCheckBox;
        private System.Windows.Forms.CheckBox PlotAutoResizeCheckBox;
        private System.Windows.Forms.CheckBox GradientFillCheckBox;
    }
}
