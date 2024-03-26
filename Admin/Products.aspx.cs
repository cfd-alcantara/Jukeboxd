﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MP2_IT114L
{
    public partial class Records : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch data from the database for the current page
                var RecordRepository = new RecordRepository();
                IEnumerable<Record> dt = RecordRepository.GetAllProducts();

                // Populate the table with data
                PopulateTable(dt);
            }


        }

        private void PopulateTable(IEnumerable<Record> dt)
        {
            foreach (var record in dt)
            {
                // Create a new row
                TableRow row = new TableRow();

                // Add cells to the row
                row.Cells.Add(new TableCell { Text = record.ProductId });
                row.Cells.Add(new TableCell { Text = record.Artist });
                row.Cells.Add(new TableCell { Text = record.Genre });
                row.Cells.Add(new TableCell { Text = record.Price.ToString() });
                row.Cells.Add(new TableCell { Text = record.Stock.ToString() });

                var deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.CssClass = "btn btn-danger asp-delete-button";
                deleteButton.Click += (sender, e) => {
                    // Handle button click event (e.g., delete the record)
                    // You can access the record associated with this button using 'record' variable
                };
                var buttonCell = new TableCell();
                buttonCell.Controls.Add(deleteButton);
                row.Cells.Add(buttonCell);

                // Add the row to the table
                MyTable.Rows.Add(row);
            }
            
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // Handle the delete button click event
            Button deleteButton = (Button)sender;
            string productId = deleteButton.ID.Split('_')[1];

            // Perform deletion operation or any other action based on productId
        }
    }
}