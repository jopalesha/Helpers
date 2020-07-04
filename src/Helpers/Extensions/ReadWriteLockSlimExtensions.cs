using System;
using System.Threading;

namespace Jopalesha.Helpers.Extensions
{
    public static class ReadWriteLockSlimExtensions
    {
        public static T ReadLock<T>(this ReaderWriterLockSlim readerWriterLock, Func<T> function)
        {
            readerWriterLock.EnterReadLock();

            try
            {
                return function();
            }
            finally
            {
                if (readerWriterLock.IsReadLockHeld)
                {
                    readerWriterLock.ExitReadLock();
                }
            }
        }

        public static void ReadLock(this ReaderWriterLockSlim readerWriterLock, Action action)
        {
            readerWriterLock.EnterReadLock();

            try
            {
                action();
            }
            finally
            {
                if (readerWriterLock.IsReadLockHeld)
                {
                    readerWriterLock.ExitReadLock();
                }
            }
        }

        public static void WriteLock(this ReaderWriterLockSlim readerWriterLock, Action action)
        {
            readerWriterLock.EnterWriteLock();

            try
            {
                action();
            }
            finally
            {
                if (readerWriterLock.IsWriteLockHeld)
                {
                    readerWriterLock.ExitWriteLock();
                }
            }
        }

        public static T WriteLock<T>(this ReaderWriterLockSlim readerWriterLock, Func<T> function)
        {
            readerWriterLock.EnterWriteLock();

            try
            {
                return function();
            }
            finally
            {
                if (readerWriterLock.IsWriteLockHeld)
                {
                    readerWriterLock.ExitWriteLock();
                }
            }
        }

        public static void UpgradableLock(this ReaderWriterLockSlim readerWriterLock, Action action)
        {
            readerWriterLock.EnterUpgradeableReadLock();


            try
            {
                action();
            }
            finally
            {
                if (readerWriterLock.IsUpgradeableReadLockHeld)
                {
                    readerWriterLock.ExitUpgradeableReadLock();
                }
            }
        }

        public static T UpgradableLock<T>(this ReaderWriterLockSlim readerWriterLock, Func<T> function)
        {
            readerWriterLock.EnterUpgradeableReadLock();

            try
            {
                return function();
            }
            finally
            {
                if (readerWriterLock.IsUpgradeableReadLockHeld)
                {
                    readerWriterLock.ExitUpgradeableReadLock();
                }
            }
        }
    }
}