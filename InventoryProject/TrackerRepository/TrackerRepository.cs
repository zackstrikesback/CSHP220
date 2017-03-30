using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDB;

namespace TrackerRepository
{
    public class TrackerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Genre { get; set; }
        public int Current { get; set; }
        public int Total { get; set; }
    }

    public class TrackerRepository
    {
        public TrackerModel Add(TrackerModel trackerModel)
        {
            var trackerDb = ToDbModel(trackerModel);

            DatabaseManager.Instance.Trackings.Add(trackerDb);
            DatabaseManager.Instance.SaveChanges();

            trackerModel = new TrackerModel
            {
                Id = trackerDb.Id,
                Name = trackerDb.Name,
                Type = trackerDb.Type,
                Genre = trackerDb.Genre,
                Current = trackerDb.Current,
                Total = trackerDb.Total
            };
            return trackerModel;
        }

        public List<TrackerModel> GetAll()
        {
            // Use .Select() to map the database trackers to TrackerModel
            var items = DatabaseManager.Instance.Trackings
              .Select(t => new TrackerModel
              {
                  Id = t.Id,
                  Name = t.Name,
                  Type = t.Type,
                  Genre = t.Genre,
                  Current = t.Current,
                  Total = t.Total
              }).ToList();

            return items;
        }

        public bool Update(TrackerModel trackerModel)
        {
            var original = DatabaseManager.Instance.Trackings.Find(trackerModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(trackerModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool UpdateProgress(TrackerModel trackerModel)
        {
            var original = DatabaseManager.Instance.Trackings.Find(trackerModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(trackerModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int trackerId)
        {
            var items = DatabaseManager.Instance.Trackings
                                .Where(t => t.Id == trackerId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Trackings.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Tracking ToDbModel(TrackerModel trackerModel)
        {
            var trackerDb = new Tracking
            {
                Id = trackerModel.Id,
                Name = trackerModel.Name,
                Type = trackerModel.Type,
                Genre = trackerModel.Genre,
                Current = trackerModel.Current,
                Total = trackerModel.Total
            };

            return trackerDb;
        }
    }
}
