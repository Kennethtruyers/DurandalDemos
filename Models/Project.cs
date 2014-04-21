using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ProjectFinder.Models
{
	public class Project
	{
		public Project()
		{
			Contributors = new List<Contributor>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public string Description { get; set; }
		public string Picture { get; set; }
		public List<Contributor> Contributors { get; set; }
		public string TagList { get; set; }

		[NotMapped]
		public List<string> Tags
		{
			get
			{
				if (string.IsNullOrEmpty(TagList))
					return new List<string>();
				return TagList.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
			}
			set
			{
				TagList = string.Join(",", value);
			}
		}
	}
}