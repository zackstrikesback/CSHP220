using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.Models
{
    public class TrackerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int Current { get; set; }
        public int Total { get; set; }

        public TrackerRepository.TrackerModel ToRepositoryModel()
        {
            var repositoryModel = new TrackerRepository.TrackerModel
            {
                Id = Id,
                Name = Name,
                Type = Type,
                Genre = Genre,
                Current = Current,
                Total = Total
            };

            return repositoryModel;
        }

        public static TrackerModel ToModel(TrackerRepository.TrackerModel respositoryModel)
        {
            var trackerModel = new TrackerModel
            {
                Id = respositoryModel.Id,
                Name = respositoryModel.Name,
                Type = respositoryModel.Type,
                Genre = respositoryModel.Genre,
                Current = respositoryModel.Current,
                Total = respositoryModel.Total
            };

            return trackerModel;
        }
    }
}
