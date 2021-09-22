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

        public void AddPettyVault(string name, decimal value)
        {
            PettyVault pettyVault = new PettyVault(name, value);
            pettyVaultsList.Add(pettyVault);
        }

        public PettyVault GetFirstIndex()
        {
            return pettyVaultsList[0];
        }
    }

    public class PettyVault
    {
        private string Name { get; set; }
        private decimal Value { get; set; }

        public PettyVault(string name, decimal value)
        {
            this.Name = name;
            this.Value = value;
        }

        public void DecreaseValue(decimal amount)
        {
            this.Value -= amount;
        }

        public void Replenish(decimal amount)
        {
            this.Value += amount;
        }

        public string GetName()
        {
            return this.Name;
        }

        public decimal GetValue()
        {
            return this.Value;
        }
    }
}
