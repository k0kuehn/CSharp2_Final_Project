using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalProject
{
    class Bank
    {
        private List<Teller> tellerList;
        public BankQueue BankQueue { get; set; }
        public CustomerList Customers { get; set; }
        public BankVault Vault { get; set; }
        public Bank(UIHelper uiHelper, CancellationToken ct, int numTellers, int numCustomers, decimal custInitialAmount, decimal initialBankVaultBalance) 
        {
            BankQueue = new BankQueue(ct);
            Customers = new CustomerList(numCustomers, custInitialAmount, uiHelper);
            Vault = new BankVault(initialBankVaultBalance);
            tellerList = new List<Teller>();
            for (int i = 0; i < numTellers; i++)
            {
                tellerList.Add(new Teller(uiHelper, ct, this));
            }
        }


    }
}
