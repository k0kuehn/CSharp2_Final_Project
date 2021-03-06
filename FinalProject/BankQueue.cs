﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace FinalProject
{
    class BankQueue
    {
        private BlockingCollection<Transaction> queue; // Is this the proper BlockingCollection type?
        private CancellationToken cancelToken;

        public BankQueue(CancellationToken ct)
        {
            queue = new BlockingCollection<Transaction>();
            cancelToken = ct;
        }

        public Transaction Dequeue()
        {
            return queue.Take(cancelToken);
        }

        public void Enqueue(Transaction t) 
        {
            queue.Add(t);
        }
    }
}
