﻿using MyStore.Infra.Persistence.Contexts;

namespace MyStore.Infra.Transaction
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly MyStoreDataContext _context;

        public UnityOfWork(MyStoreDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Não faz nada ;)
        }
    }
}
