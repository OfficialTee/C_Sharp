using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class Interaction
    {
        public void SetCategories(List<Category> categories, Purse purse)
        {
            purse.Categories = categories;
        }

        public int CheckBalance(Purse purse)
        {
            return purse.Balance;
        }

        public string GetIncomeLastMonth(List<Transaction> transactions)
        {
            string result = "";
            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Sum > 0 && transactions[i].Date.Month == DateTime.Now.Month)
                    result = result + transactions[i].Sum.ToString() + " in " + transactions[i].Currency.ToString() + " ";
            }
            return result;
        }

        public string GetExpensesLastMonth(List<Transaction> transactions)
        {
            string result = "";
            for (int i = 0; i < transactions.Count; i++)
            {
                if (transactions[i].Sum < 0 && transactions[i].Date.Month == DateTime.Now.Month)
                    result = result + transactions[i].Sum.ToString() + " in " + transactions[i].Currency.ToString() + " ";
            }
            return result;
        }

        public void DeleteTransaction(Transaction transaction, Purse purse)
        {
            purse.Transactions.Remove(transaction);
        }

        public string GetLastTansactions(Purse purse)
        {
            string result = "";
            int all = purse.Transactions.Count;
            if (all < 10)
            {
                foreach (Transaction i in purse.Transactions)
                {
                    result += i.Id.ToString() + " " +
                        i.Sum.ToString() + " " +
                        i.Currency.ToString() + " " +
                        i.Category.Name.ToString() + " " +
                        i.Description.ToString() + " " +
                        i.Date.ToString() + " " +
                        i.PurseId.ToString() + " " +
                        i.UserId.ToString() + "  ";
                }
            }
            else
            {
                for(int i = all - 10; i < all; i++)
                {
                    result += purse.Transactions[i].Id.ToString() + " " +
                        purse.Transactions[i].Sum.ToString() + " " +
                        purse.Transactions[i].Currency.ToString() + " " +
                        purse.Transactions[i].Category.Name.ToString() + " " +
                        purse.Transactions[i].Description.ToString() + " " +
                        purse.Transactions[i].Date.ToString() + " " +
                        purse.Transactions[i].PurseId.ToString() + " " +
                        purse.Transactions[i].UserId.ToString() + "  ";
                }
            }
            return result;
        }

        public string DownloadTransactionsFromIndex(Purse purse, int index)
        {
            string result = "";
            int all = purse.Transactions.Count;
            if (index - 1 < all)
            {
                for (int i = index - 1; i < all; i++)
                {
                    result += purse.Transactions[i].Id.ToString() + " " +
                        purse.Transactions[i].Sum.ToString() + " " +
                        purse.Transactions[i].Currency.ToString() + " " +
                        purse.Transactions[i].Category.Name.ToString() + " " +
                        purse.Transactions[i].Description.ToString() + " " +
                        purse.Transactions[i].Date.ToString() + " " +
                        purse.Transactions[i].PurseId.ToString() + " " +
                        purse.Transactions[i].UserId.ToString() + "  ";
                }
            }
            else
            {
                result += "No such index";
            }

            return result;
        }
    }
}