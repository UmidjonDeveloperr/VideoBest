using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;

namespace VideoBest.Brokers.Storages
{
	public partial class StorageBroker : EFxceptionsContext , IStorageBroker
	{
		private readonly IConfiguration configuration;

		public StorageBroker(IConfiguration configuration)
		{
			this.configuration = configuration;
			this.Database.Migrate();
		}

		public async ValueTask<T> InsertAsync<T>(T @object)
		{
			using var broker = new StorageBroker(this.configuration);
			broker.Entry(@object).State = EntityState.Added;
			await broker.SaveChangesAsync();

			return @object;
		}

		public IQueryable<T> SelectAll<T>() where T : class
		{
			using var broker = new StorageBroker(this.configuration);

			return broker.Set<T>();
		}

		public async ValueTask<T> SelectAsync<T>(params object[] objectsId) where T : class
		{
			using var broker = new StorageBroker(this.configuration);

			return await broker.FindAsync<T>(objectsId);
		}

		public async ValueTask<T> UpdateAsync<T>(T @object)
		{
			using var broker = new StorageBroker(this.configuration);
			broker.Entry(@object).State = EntityState.Modified;
			await broker.SaveChangesAsync();

			return @object;
		}

		public async ValueTask<T> DeleteAsync<T>(T @object)
		{
			using var broker = new StorageBroker(this.configuration);
			broker.Entry(@object).State = EntityState.Deleted;
			await broker.SaveChangesAsync();

			return @object;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionString =
				configuration.GetConnectionString(name: "DefaultConnection");

			optionsBuilder.UseSqlServer(connectionString);
		}

		public override void Dispose()
		{ }
	}
}
