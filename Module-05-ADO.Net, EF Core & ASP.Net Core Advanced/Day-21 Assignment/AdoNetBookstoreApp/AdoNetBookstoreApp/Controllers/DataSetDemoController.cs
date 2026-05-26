using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using AdoNetBookstoreApp.DataAccess;

namespace AdoNetBookstoreApp.Controllers
{
    public class DataSetDemoController : Controller
    {
        private readonly BookDataAccess _dataAccess;

        public DataSetDemoController(BookDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // Route: /DataSetDemo
        public IActionResult Index()
        {
            var dataSet = _dataAccess.GetBooksDataSet();
            var dataTable = dataSet.Tables["Books"] ?? new DataTable();
            return View(dataTable);
        }

        // Route: /DataSetDemo/ModifyDisconnected (POST)
        [HttpPost]
        public IActionResult ModifyDisconnected(string title, string author, string isbn, decimal price)
        {
            var dataSet = _dataAccess.GetBooksDataSet();
            var table = dataSet.Tables["Books"];

            if (table != null)
            {
                // Disconnected addition: create a new row in the disconnected DataTable collection
                var newRow = table.NewRow();
                newRow["BookId"] = new Random().Next(1000, 9999); // Simulated ID
                newRow["Title"] = title;
                newRow["Author"] = author;
                newRow["ISBN"] = isbn;
                newRow["Price"] = price;

                table.Rows.Add(newRow);

                // Batch update the database disconnectedly using SqlDataAdapter
                _dataAccess.UpdateBooksDisconnected(dataSet);
                TempData["Success"] = "Disconnected DataTable row added and synced successfully using SqlDataAdapter!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
