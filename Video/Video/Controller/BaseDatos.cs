using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Video.Models;

namespace Video.Controller
{
    public class BaseDatos
    {
        readonly SQLiteAsyncConnection db;

        public BaseDatos(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

           db.CreateTableAsync<Cvideo>().Wait();
        }

        public Task<List<Cvideo>> GetVideosLista()
        {
            return db.Table<Cvideo>().ToListAsync();
        }

        public Task<Cvideo> GetCodVideo(int codv)
        {
            return db.Table<Cvideo>()
                .Where(i => i.cod == codv)
                .FirstOrDefaultAsync();
        }

        
        public Task<int> GuardarVideo(Cvideo videoo)
        {
            if (videoo.cod != 0)
            {
                return db.UpdateAsync(videoo);
            }
            else
            {
                return db.InsertAsync(videoo);
            }

        }

        public Task<int> DeleteVideo(Cvideo videoo)
        {
            return db.DeleteAsync(videoo);
        }
    }
}
