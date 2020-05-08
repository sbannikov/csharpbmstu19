namespace Core.Code
{
    using Core.Interface;
    using System;

    public sealed class DbDataProviderFactory
	{
        #region Singleton

        private static readonly Lazy<DbDataProviderFactory> _lazy = new Lazy<DbDataProviderFactory>(() => new DbDataProviderFactory());

        public static DbDataProviderFactory Instance { get { return _lazy.Value; } }

        private DbDataProviderFactory() { }

        #endregion

        public IDbDataProvider CreateDbProvider()
        {
            return new DbDataProvider();
        }
    }
}
