using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Linkup_Finance.Managers
{
    public class BankManager
    {
        public List<PettyVault> pettyVaultsList;
        public List<Bank> banksList;

        public BankManager()
        {
            pettyVaultsList = new List<PettyVault>();
            banksList = new List<Bank>();
        }

        public void AddPettyVault(string name, decimal value, decimal amount = 0.00m)
        {
            PettyVault pettyVault = new PettyVault(name, value, amount);
            pettyVaultsList.Add(pettyVault);
        }

        public PettyVault GetFirstIndex()
        {
            return pettyVaultsList[0];
        }

        public PettyVault GetPettyVault(string name)
        {
            foreach (PettyVault vault in pettyVaultsList)
            {
                if (name == vault.GetName())
                    return vault;
            }

            return null;
        }

        public void RemovePettyVault(PettyVault vault)
        {
            pettyVaultsList.Remove(vault);

            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.RemoveAt(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(vault.GetName()) + 2);
            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.RemoveAt(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(vault.GetName()) + 1);
            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.RemoveAt(Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(vault.GetName()));
            Linkup_Finance.Properties.Settings.Default.Save();
        }

        public bool BankExists(string name)
        {
            foreach(Bank bank in banksList)
                if (bank.GetBankName().ToLower() == name.ToLower())
                    return true;

            return false;
        }

        public bool AddBank(string name, string accountID, decimal balance)
        {
            Bank bank = new Bank(name, accountID, balance);
            banksList.Add(bank);

            using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string insertQuery = "INSERT INTO Banks(Name, AccountId, Balance)" +
                                         $" VALUES(@Name, @AccountId, @Balance)";
                    SqlCommand command = new SqlCommand(insertQuery, con);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@AccountId", accountID);
                    command.Parameters.AddWithValue("@Balance", balance);
                    
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<Bank> RetrieveBanks(Linkup_Finance.LinkupDatabaseDataSetTableAdapters.BanksTableAdapter adapter)
        {
            int bound = adapter.GetData().Rows.Count;

            for (int i = 0; i < bound; i++)
            {
                string name = adapter.GetData().Rows[i].ItemArray[1].ToString();
                string accountID = adapter.GetData().Rows[i].ItemArray[2].ToString();
                decimal balance = (decimal)adapter.GetData().Rows[i].ItemArray[3];

                if (!BankExists(name))
                    banksList.Add(new Bank(name, accountID, balance));
            }

            return banksList;
        }

        public decimal GetTotalPettyVaultsAmount()
        {
            decimal total = 0.00m;

            foreach (PettyVault vault in pettyVaultsList)
                total += vault.GetAmount();

            return total; 
        } 

        public int GetTotalPettyVaultsBound()
        {
            int bound = 0;

            foreach (PettyVault vault in pettyVaultsList)
                bound += int.Parse(vault.GetValue().ToString());

            return bound;
        }

        public decimal GetTotalBankAmount()
        {
            decimal total = 0.00m;

            foreach (Bank bank in banksList)
                total += bank.GetBalance();

            return total;
        }

        public decimal GetTotalBankAmount(DataTable dataTable)
        {
            decimal total = 0.00m;

            for(int i = 0; i < dataTable.Rows.Count; i++)
                total += (decimal)dataTable.Rows[i].ItemArray[3];

            return total;
        }

        public Bank GetBank(string name)
        {
            foreach(Bank bank in banksList)
                if (bank.GetBankName().ToLower() == name.ToLower())
                    return bank;

            return null;
        }

        public bool RemoveBank(Bank bank)
        {
            string name = bank.GetBankName();
            string accountId = bank.GetAccountId();

            banksList.Remove(bank);

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteQuery = "DELETE FROM Banks " +
                                         "WHERE Name=@Name and AccountId=@AccountId";
                    SqlCommand command = new SqlCommand(deleteQuery, con);
                    
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@AccountId", accountId);
                    
                    con.Open();
                    command.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool RemoveLog(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteBankLogQuery = "DELETE FROM BankLogs " +
                                                "WHERE Id=@Id";

                    SqlCommand deleteBankLogCommand = new SqlCommand(deleteBankLogQuery, con);
                    con.Open();

                    deleteBankLogCommand.Parameters.AddWithValue("@Id", id);
                    deleteBankLogCommand.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                    //return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public bool ResetData()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    string deleteBankQuery = "DELETE FROM Banks";
                    string deleteBankLogsQuery = "DELETE FROM BankLogs";
                    SqlCommand bankCommand = new SqlCommand(deleteBankQuery, con);
                    SqlCommand bankLogsCommand = new SqlCommand(deleteBankLogsQuery, con);

                    con.Open();

                    bankCommand.ExecuteNonQuery();
                    bankLogsCommand.ExecuteNonQuery();

                    banksList.Clear();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

    public class Bank
    {
        private string Name { get; set; }
        private string AccountID { get; set; }
        private decimal Balance { get; set; }

        public Bank(string name, string accountID, decimal balance)
        {
            this.Name = name;
            this.AccountID = accountID;
            this.Balance = balance;
        }

        public string GetBankName()
        {
            return this.Name;
        }

        public decimal GetBalance()
        {
            return this.Balance;
        }

        public string GetAccountId()
        {
            return this.AccountID;
        }

        public void Deposit(decimal value, bool changeDB = true)
        {
            decimal prevBalance = this.Balance;
            this.Balance += value;

            if (changeDB)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
                {
                    try
                    {
                        con.Open();
                        string updateQuery = "UPDATE Banks " +
                                             "SET Balance=@Balance " +
                                             "WHERE Name=@Name";
                        SqlCommand command = new SqlCommand(updateQuery, con);
                        command.Parameters.AddWithValue("@Balance", this.Balance);
                        command.Parameters.AddWithValue("@Name", this.Name);

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

                SubmitLog(prevBalance, "Income", "Deposit", DateTime.Now, "Deposit");
            }
        }

        public bool SubmitLog(decimal amount, string type, string reason, DateTime date, string tpName, bool isSummed = true, string project = null)
        {
            if (!isSummed)
            {
                if (type == "Income")
                    this.Balance += amount;
                else
                    this.Balance -= amount;
            }

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string insertQuery = "INSERT INTO BankLogs(Bank, Balance, PrevBalance, Type, Reason, Date, ProjectName, tpName)" +
                                         $" VALUES(@Bank, @Balance, @PrevBalance, @Type, @Reason, @Date, \'{project}\', @tpName)";
                    string updateQuery = "UPDATE Banks " +
                                         "SET Balance=@Balance " +
                                         "WHERE Name=@Name";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, con);
                    SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                    
                    insertCommand.Parameters.AddWithValue("@Bank", this.Name);
                    insertCommand.Parameters.AddWithValue("@Balance", this.Balance);
                    insertCommand.Parameters.AddWithValue("@PrevBalance", (type == "Income") ? this.Balance - amount : this.Balance + amount);
                    insertCommand.Parameters.AddWithValue("@Type", type);
                    insertCommand.Parameters.AddWithValue("@Reason", reason);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.Parameters.AddWithValue("@tpName", tpName);
                    insertCommand.ExecuteNonQuery();

                    updateCommand.Parameters.AddWithValue("@Balance", this.Balance);
                    updateCommand.Parameters.AddWithValue("@Name", this.Name);
                    updateCommand.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static bool SubmitLog(decimal amount, string reason, DateTime date, string tpName, string project = null)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
            {
                try
                {
                    con.Open();

                    string insertQuery = "INSERT INTO BankLogs(Bank, Balance, PrevBalance, Type, Reason, Date, ProjectName, tpName)" +
                                         $" VALUES(@Bank, @Balance, @PrevBalance, @Type, @Reason, @Date, \'{project}\', @tpName)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, con);

                    insertCommand.Parameters.AddWithValue("@Bank", "Petty");
                    insertCommand.Parameters.AddWithValue("@Balance", amount);
                    insertCommand.Parameters.AddWithValue("@PrevBalance", 0.00m);
                    insertCommand.Parameters.AddWithValue("@Type", "Petty Expense");
                    insertCommand.Parameters.AddWithValue("@Reason", reason);
                    insertCommand.Parameters.AddWithValue("@Date", date);
                    insertCommand.Parameters.AddWithValue("@tpName", tpName);
                    insertCommand.ExecuteNonQuery();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
    }

    public class PettyVault
    {
        private string Name { get; set; }
        private decimal Value { get; set; }
        private decimal Amount { get; set; }

        public PettyVault(string name, decimal value, decimal amount = 0.00m)
        {
            this.Name = name;
            this.Value = value;
            this.Amount = (amount > 0.00m) ? amount : value;
        }

        public void DecreaseValue(decimal amount)
        {
            this.Amount -= amount;
            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(this.Name) + 2] = this.Amount.ToString();
            Linkup_Finance.Properties.Settings.Default.Save();
        }

        public void Replenish(decimal amount, Bank bank, bool changeDB = true)
        {
            if (changeDB)
            {
                DateTime date = DateTime.Now;
                bank.Withdraw(amount);

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Linkup_Finance.Properties.Settings.LinkupDBConfig"].ConnectionString))
                {
                    try
                    {
                        string insertQuery = "INSERT INTO Expense(ExpName, Product, Amount, Type, VAT, Withholding, Bank, Reason, Date, Attachement, Total, Project, Receipt, Tin)" +
                                             $" VALUES(@ExpName, @Product,@Amount,@Type,@VAT,@Withholding,@Bank,@Reason,@Date,\'{null}\',@Total,@Project,@Receipt,\'{null}\')";
                        string insertBankQuery = "INSERT INTO BankLogs(Bank, Balance, PrevBalance, Type, Reason, Date, ProjectName, tpName)" +
                                             $" VALUES(@Bank, @Balance, @PrevBalance, @Type, @Reason, @Date, \'{null}\', @tpName)";
                        string updateBankQuery = "UPDATE Banks " +
                                             "SET Balance=@Balance " +
                                             "WHERE Name=@Name";
                        SqlCommand command = new SqlCommand(insertQuery, con);
                        con.Open();

                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Total", amount);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@Type", "Petty Deposit");
                        command.Parameters.AddWithValue("@Bank", bank.GetBankName());
                        command.Parameters.AddWithValue("@Reason", "Petty Cash Replenish");
                        command.Parameters.AddWithValue("@Project", "");
                        command.Parameters.AddWithValue("@Receipt", 0);
                        command.Parameters.AddWithValue("@ExpName", "Petty Deposit");
                        command.Parameters.AddWithValue("@Product", "");
                        command.Parameters.AddWithValue("@VAT", 0m);
                        command.Parameters.AddWithValue("@Withholding", 0m);

                        command.ExecuteNonQuery();

                        command = new SqlCommand(insertBankQuery, con);

                        command.Parameters.AddWithValue("@Bank", bank.GetBankName());
                        command.Parameters.AddWithValue("@Balance", bank.GetBalance());
                        command.Parameters.AddWithValue("@PrevBalance", bank.GetBalance() + amount);
                        command.Parameters.AddWithValue("@Type", "Petty Deposit");
                        command.Parameters.AddWithValue("@Reason", "Petty Cash Replenish");
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@tpName", "Petty Deposit");

                        command.ExecuteNonQuery();

                        command = new SqlCommand(updateBankQuery, con);

                        command.Parameters.AddWithValue("@Balance", bank.GetBalance());
                        command.Parameters.AddWithValue("@Name", bank.GetBankName());

                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error occured: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            
            this.Amount += amount;
            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(this.Name) + 2] = this.Amount.ToString();
            Linkup_Finance.Properties.Settings.Default.Save();
        }

        public string GetName()
        {
            return this.Name;
        }

        public decimal GetValue()
        {
            return this.Value;
        }

        public decimal GetAmount()
        {
            return this.Amount;
        }

        public void SetValue(decimal value)
        {
            this.Value = value;
            Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary[Linkup_Finance.Properties.Settings.Default.PettyVaultDictionary.IndexOf(this.Name) + 1] = value.ToString();
            Linkup_Finance.Properties.Settings.Default.Save();
        }
    }
}
