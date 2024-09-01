namespace BeautifulFundamental.Tests.TestObjects
{
	public class TestDbContext : BaseDbContext<TestEntityDto>
	{
		public TestDbContext(IDbContextSettings dbContextSettings) : base(dbContextSettings)
		{
		}

		protected override ReloadingBehavior GetReloadingBehavior()
		{
			return new ReloadingBehavior
			{
				ExceptWithEntities = true
			};
		}
	}
}