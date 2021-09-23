using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkup_Finance.Managers
{
    public class BankManager
    {
        //List<Bank> banksList = new List<Bank>();
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

        public Bank GetBank(string name)
        {
            foreach(Bank bank in banksList)
                if (bank.GetBankName().ToLower() == name.ToLower())
                    return bank;

            return null;
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
        }

        public void Replenish()
        {
            this.Amount += this.Value;
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
