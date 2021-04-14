using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using festival.model;
using festival.model.validator;


namespace festival.persistance
{
    public class ShowsDBRepository : ShowsRepositoryInterface
    {
        private ShowValidator vali = new ShowValidator();
        public IEnumerable<Show> findShowByDate(DateTime date)
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Show> shows = new List<Show>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select S.*,A.name from Shows S left join Artists A where A.ID=S.artistID and S.date between @date1 and @date2";
                
                DateTime startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0); 
                DateTime endDate = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                
                var paramDate1 = comm.CreateParameter();
                paramDate1.ParameterName = "@date1";
                paramDate1.Value = startDate;
                comm.Parameters.Add(paramDate1);
               
                
                var paramDate2 = comm.CreateParameter();
                paramDate2.ParameterName = "@date2";
                paramDate2.Value = endDate;
                comm.Parameters.Add(paramDate2);
               
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ID = dataR.GetInt32(0);
                        String location = dataR.GetString(1);
                        DateTime Sdate = Convert.ToDateTime(dataR.GetDateTime(2));
                        int artistID = dataR.GetInt32(3);
                        String name = dataR.GetString(4);
                        int totalSeats = dataR.GetInt32(5);
                        int soldSeats = dataR.GetInt32(6);
                        String artistName = dataR.GetString(7);
                        
                        Artist artist = new Artist(artistID, artistName);
                        Show show = new Show(ID, name, location, Sdate, artist, totalSeats, soldSeats);

                        shows.Add(show);
                    }
                }
            }

            return shows;
        }

        public void updateSeats(int showId, int seats)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Shows set soldSeats = soldSeats+ @seats where Id = @Id ";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = showId;
                comm.Parameters.Add(paramId);
                
                var paramSeats = comm.CreateParameter();
                paramSeats.ParameterName = "@seats";
                paramSeats.Value = seats;
                comm.Parameters.Add(paramSeats);

                comm.ExecuteNonQuery();
            }
            con.Close();
        }
        public IEnumerable<Show> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Show> shows = new List<Show>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select S.*, A.name from Shows S left join Artists A on S.artistID = A.ID";
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ID = dataR.GetInt32(0);
                        String location = dataR.GetString(1);
                        DateTime date = Convert.ToDateTime(dataR.GetDateTime(2));
                        int artistID = dataR.GetInt32(3);
                        String name = dataR.GetString(4);
                        int totalSeats = dataR.GetInt32(5);
                        int soldSeats = dataR.GetInt32(6);
                        String artistName = dataR.GetString(7);
                        
                        Artist artist = new Artist(artistID, artistName);
                        Show show = new Show(ID, name, location, date, artist, totalSeats, soldSeats);
                        shows.Add(show);
                    }
                }
            }
            con.Close();
            return shows;
        }

        public Show Save(Show entity)
        {

            try
            {
                vali.Validate(entity);
                var con = DBUtils.getConnection();
                using (var comm = con.CreateCommand())
                {
                    comm.CommandText =
                        "insert into Shows values (@showID, @location, @date, @artistId, @name, @totalSeats, @soldSeats)";

                    var paramId = comm.CreateParameter();
                    paramId.ParameterName = "@showID";
                    paramId.Value = entity.ID;
                    comm.Parameters.Add(paramId);

                    var paramLocation = comm.CreateParameter();
                    paramLocation.ParameterName = "@location";
                    paramLocation.Value = entity.location;
                    comm.Parameters.Add(paramLocation);

                    var paramDate = comm.CreateParameter();
                    paramDate.ParameterName = "@date";
                    paramDate.Value = entity.date;
                    comm.Parameters.Add(paramDate);

                    var paramArtistId = comm.CreateParameter();
                    paramArtistId.ParameterName = "@artistId";
                    paramArtistId.Value = entity.artist.ID;
                    comm.Parameters.Add(paramArtistId);

                    var paramName = comm.CreateParameter();
                    paramName.ParameterName = "@name";
                    paramName.Value = entity.name;
                    comm.Parameters.Add(paramName);

                    var paramTotalSeats = comm.CreateParameter();
                    paramTotalSeats.ParameterName = "@totalSeats";
                    paramTotalSeats.Value = entity.totalSeats;
                    comm.Parameters.Add(paramTotalSeats);

                    var paramSoldSeats = comm.CreateParameter();
                    paramSoldSeats.ParameterName = "@soldSeats";
                    paramSoldSeats.Value = entity.soldSeats;
                    comm.Parameters.Add(paramSoldSeats);


                    var result = comm.ExecuteNonQuery();
                    if (result == 0)
                        Trace.WriteLine("No shows added!");
                    else 
                        Trace.WriteLine("Show added");
                }
            }
            catch (ValidationException val) {
                Trace.WriteLine(val.ToString());
            }

            return entity;
        }

        public bool hasAvailableSeats(int showId, int seats)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select totalSeats,soldSeats from Shows where ID = @Id";
                
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = showId;
                comm.Parameters.Add(paramId);
                
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                   
                        int totalSeats = dataR.GetInt32(0);
                        int soldSeats = dataR.GetInt32(1);
                        if (totalSeats - soldSeats < seats)
                            return false;
                        return true;
                    }
                }
            }

            return false;
   
           
        }
    }
}
