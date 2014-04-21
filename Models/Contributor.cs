using System.Collections.Generic;

namespace ProjectFinder.Models
{
	public class Contributor
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Picture { get; set; }

		public List<Project> Projects { get; set; }
	}
}