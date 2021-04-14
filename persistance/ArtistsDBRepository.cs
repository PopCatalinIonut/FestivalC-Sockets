
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using festival.model;
using festival.model.validator;

namespace festival.persistance
{
    public class ArtistsDBRepository : ArtistsRepositoryInterface
    {
        private ArtistValidator vali = new ArtistValidator();
        public IEnumerable<Artist> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Artist> artists = new List<Artist>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Artists ";
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ID = dataR.GetInt32(0);
                        String name = dataR.GetString(1);

                        Artist artist = new Artist(ID,name);
                        artists.Add(artist);
                    }
                }
            }
            con.Close();
            return artists;
        }

        public Artist Save(Artist entity)
        {
            var con = DBUtils.getConnection();
            try
            {
                vali.Validate(entity);
                using (var comm = con.CreateCommand())
                {
                    comm.CommandText =
                        "insert into Artists values (@ID, @name)";

                    var paramId = comm.CreateParameter();
                    paramId.ParameterName = "@ID";
                    paramId.Value = entity.ID;
                    comm.Parameters.Add(paramId);


                    var paramName = comm.CreateParameter();
                    paramName.ParameterName = "@name";
                    paramName.Value = entity.name;
                    comm.Parameters.Add(paramName);

                    var result = comm.ExecuteNonQuery();
                    if (result == 0)
                        Trace.WriteLine("No artists added!");
                    else
                        Trace.WriteLine("Artist added");
                }
            }
            catch (ValidationException val)
            {
                Trace.WriteLine(val.ToString());
            }
            finally
            {
                con.Close();
            }

            return entity;
        }
        
    }
}
