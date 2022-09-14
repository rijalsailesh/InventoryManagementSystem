namespace Digitalkirana.Views
{
    partial class TransactionsDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsDetails));
            this.dataGridViewPurchaseDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.totalAmt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPurchaseDetails
            // 
            this.dataGridViewPurchaseDetails.AllowUserToAddRows = false;
            this.dataGridViewPurchaseDetails.AllowUserToDeleteRows = false;
            this.dataGridViewPurchaseDetails.AllowUserToResizeColumns = false;
            this.dataGridViewPurchaseDetails.AllowUserToResizeRows = false;
            this.dataGridViewPurchaseDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridViewPurchaseDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPurchaseDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewPurchaseDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchaseDetails.Location = new System.Drawing.Point(12, 53);
            this.dataGridViewPurchaseDetails.Name = "dataGridViewPurchaseDetails";
            this.dataGridViewPurchaseDetails.ReadOnly = true;
            this.dataGridViewPurchaseDetails.RowHeadersVisible = false;
            this.dataGridViewPurchaseDetails.RowHeadersWidth = 51;
            this.dataGridViewPurchaseDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPurchaseDetails.RowTemplate.Height = 24;
            this.dataGridViewPurchaseDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPurchaseDetails.Size = new System.Drawing.Size(1104, 523);
            this.dataGridViewPurchaseDetails.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Total:";
            // 
            // totalAmt
            // 
            this.totalAmt.AutoSize = true;
            this.totalAmt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalAmt.Location = new System.Drawing.Point(80, 9);
            this.totalAmt.Name = "totalAmt";
            this.totalAmt.Size = new System.Drawing.Size(0, 23);
            this.totalAmt.TabIndex = 29;
            // 
            // TransactionsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 588);
            this.Controls.Add(this.totalAmt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewPurchaseDetails);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransactionsDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transactions Details";
            this.Load += new System.EventHandler(this.TransactionsDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchaseDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPurchaseDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalAmt;
    }
}