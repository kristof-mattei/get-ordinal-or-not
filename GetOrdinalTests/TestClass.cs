namespace GetOrdinalOrNot.Tests
{
    using System;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestClass
    {
        private SqlConnection _sqlConnection;
        private const int Iterations = 1000;
        private readonly string _query = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GetOrdinalOrNot.Tests.Query.sql")).ReadToEnd();

        [TestInitialize]
        public void TestInitialize()
        {
            this._sqlConnection = new SqlConnection("Data Source=.; Trusted_Connection=SSPI");
            this._sqlConnection.Open();
        }

        private void InvokeQuery(Action<SqlDataReader> mapObject)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Iterations; i++)
            {
                using (var sqlCommand = new SqlCommand(this._query, this._sqlConnection))
                {
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.NextResult())
                        {
                            mapObject(sqlDataReader);
                        }
                    }
                }
            }

            stopwatch.Stop();

            Debug.WriteLine("Running {0} queries took {1} milliseconds!", Iterations, stopwatch.ElapsedMilliseconds);
        }

        [TestMethod()]
        [Description("Runs the query x times with GetInt32/GetString, ... (not using GetOrdinal)")]
        public void CreateWithoutGetOrdinal()
        {
            Action<SqlDataReader> mapSalesOrderHeader = sqlDataReader =>
                                                        {
                                                            // ReSharper disable RedundantArgumentName
                                                            var temp = new SalesOrderHeader(
                                                                salesOrderID: sqlDataReader.GetInt32(0),
                                                                revisionNumber: sqlDataReader.GetInt16(1),
                                                                orderDate: sqlDataReader.GetDateTime(2),
                                                                dueDate: sqlDataReader.GetDateTime(3),
                                                                shipDate: sqlDataReader.GetDateTime(4),
                                                                status: sqlDataReader.GetInt16(5),
                                                                onlineOrderFlag: sqlDataReader.GetBoolean(6),
                                                                salesOrderNumber: sqlDataReader.GetString(7),
                                                                purchaseOrderNumber: sqlDataReader.GetString(8),
                                                                accountNumber: sqlDataReader.GetString(9),
                                                                customerID: sqlDataReader.GetInt32(10),
                                                                salesPersonID: sqlDataReader.GetInt32(11),
                                                                territoryID: sqlDataReader.GetInt32(12),
                                                                billToAddressID: sqlDataReader.GetInt32(13),
                                                                shipToAddressID: sqlDataReader.GetInt32(14),
                                                                shipMethodID: sqlDataReader.GetInt32(15),
                                                                creditCardID: sqlDataReader.GetInt32(16),
                                                                creditCardApprovalCode: sqlDataReader.GetString(17),
                                                                currencyRateID: sqlDataReader.GetInt32(18),
                                                                subTotal: sqlDataReader.GetDecimal(19),
                                                                taxAmt: sqlDataReader.GetDecimal(20),
                                                                freight: sqlDataReader.GetDecimal(21),
                                                                totalDue: sqlDataReader.GetDecimal(22),
                                                                comment: sqlDataReader.GetString(23),
                                                                rowguid: sqlDataReader.GetGuid(24),
                                                                modifiedDate: sqlDataReader.GetDateTime(25));
                                                            // ReSharper restore RedundantArgumentName
                                                        };


            this.InvokeQuery(mapSalesOrderHeader);
        }

        [Description("Runs the query x times with GetOrdinal, we resolve the column ordinal first through the column name.")]
        [TestMethod()]
        public void CreateWithGetOrdinal()
        {
            Action<SqlDataReader> mapSalesOrderHeader = sqlDataReader =>
                                                        {
                                                            int salesOrderID = sqlDataReader.GetOrdinal("SalesOrderID");
                                                            int revisionNumber = sqlDataReader.GetOrdinal("RevisionNumber");
                                                            int orderDate = sqlDataReader.GetOrdinal("OrderDate");
                                                            int dueDate = sqlDataReader.GetOrdinal("DueDate");
                                                            int shipDate = sqlDataReader.GetOrdinal("ShipDate");
                                                            int status = sqlDataReader.GetOrdinal("Status");
                                                            int onlineOrderFlag = sqlDataReader.GetOrdinal("OnlineOrderFlag");
                                                            int salesOrderNumber = sqlDataReader.GetOrdinal("SalesOrderNumber");
                                                            int purchaseOrderNumber = sqlDataReader.GetOrdinal("PurchaseOrderNumber");
                                                            int accountNumber = sqlDataReader.GetOrdinal("AccountNumber");
                                                            int customerID = sqlDataReader.GetOrdinal("CustomerID");
                                                            int salesPersonID = sqlDataReader.GetOrdinal("SalesPersonID");
                                                            int territoryID = sqlDataReader.GetOrdinal("TerritoryID");
                                                            int billToAddressID = sqlDataReader.GetOrdinal("BillToAddressID");
                                                            int shipToAddressID = sqlDataReader.GetOrdinal("ShipToAddressID");
                                                            int shipMethodID = sqlDataReader.GetOrdinal("ShipMethodID");
                                                            int creditCardID = sqlDataReader.GetOrdinal("CreditCardID");
                                                            int creditCardApprovalCode = sqlDataReader.GetOrdinal("CreditCardApprovalCode");
                                                            int currencyRateID = sqlDataReader.GetOrdinal("CurrencyRateID");
                                                            int subTotal = sqlDataReader.GetOrdinal("SubTotal");
                                                            int taxAmt = sqlDataReader.GetOrdinal("TaxAmt");
                                                            int freight = sqlDataReader.GetOrdinal("Freight");
                                                            int totalDue = sqlDataReader.GetOrdinal("TotalDue");
                                                            int comment = sqlDataReader.GetOrdinal("Comment");
                                                            int rowguid = sqlDataReader.GetOrdinal("rowguid");
                                                            int modifiedDate = sqlDataReader.GetOrdinal("ModifiedDate");
                                                            // ReSharper disable RedundantArgumentName


                                                            var temp = new SalesOrderHeader(
                                                                salesOrderID: sqlDataReader.GetInt32(salesOrderID),
                                                                revisionNumber: sqlDataReader.GetInt16(revisionNumber),
                                                                orderDate: sqlDataReader.GetDateTime(orderDate),
                                                                dueDate: sqlDataReader.GetDateTime(dueDate),
                                                                shipDate: sqlDataReader.GetDateTime(shipDate),
                                                                status: sqlDataReader.GetInt16(status),
                                                                onlineOrderFlag: sqlDataReader.GetBoolean(onlineOrderFlag),
                                                                salesOrderNumber: sqlDataReader.GetString(salesOrderNumber),
                                                                purchaseOrderNumber: sqlDataReader.GetString(purchaseOrderNumber),
                                                                accountNumber: sqlDataReader.GetString(accountNumber),
                                                                customerID: sqlDataReader.GetInt32(customerID),
                                                                salesPersonID: sqlDataReader.GetInt32(salesPersonID),
                                                                territoryID: sqlDataReader.GetInt32(territoryID),
                                                                billToAddressID: sqlDataReader.GetInt32(billToAddressID),
                                                                shipToAddressID: sqlDataReader.GetInt32(shipToAddressID),
                                                                shipMethodID: sqlDataReader.GetInt32(shipMethodID),
                                                                creditCardID: sqlDataReader.GetInt32(creditCardID),
                                                                creditCardApprovalCode: sqlDataReader.GetString(creditCardApprovalCode),
                                                                currencyRateID: sqlDataReader.GetInt32(currencyRateID),
                                                                subTotal: sqlDataReader.GetDecimal(subTotal),
                                                                taxAmt: sqlDataReader.GetDecimal(taxAmt),
                                                                freight: sqlDataReader.GetDecimal(freight),
                                                                totalDue: sqlDataReader.GetDecimal(totalDue),
                                                                comment: sqlDataReader.GetString(comment),
                                                                rowguid: sqlDataReader.GetGuid(rowguid),
                                                                modifiedDate: sqlDataReader.GetDateTime(modifiedDate)
                                                                );
                                                            // ReSharper restore RedundantArgumentName
                                                        };


            this.InvokeQuery(mapSalesOrderHeader);
        }


        [TestCleanup]
        public
        void TestCleanup()
        {
            this._sqlConnection.Dispose();
        }
    }

    public class SalesOrderHeader
    {
        // ReSharper disable UnusedParameter.Local
        public SalesOrderHeader(int salesOrderID, short revisionNumber, DateTime orderDate, DateTime dueDate, DateTime shipDate, short status, bool onlineOrderFlag, string salesOrderNumber, string purchaseOrderNumber, string accountNumber, int customerID, int salesPersonID, int territoryID, int billToAddressID, int shipToAddressID, int shipMethodID, int creditCardID, string creditCardApprovalCode, int currencyRateID, decimal subTotal, decimal taxAmt, decimal freight, decimal totalDue, string comment, Guid rowguid, DateTime modifiedDate)
            // ReSharper restore UnusedParameter.Local
        {
        }
    }
}