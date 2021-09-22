using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkup_Finance.Managers
{
    public class BankManager
    {
        //List<Bank> banksList = new List<Bank>();
        public List<PettyVault> pettyVaultsList;

        public BankManager()
        {
             pettyVaultsList = new List<PettyVault>();
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
