﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string constring = "Data Source=DESKTOP-C3KCD2B;Initial Catalog=WCFReservasi1; Presist Security Info=True; User ID=sa; Password=chika.00";
        SqlConnection connection;
        SqlCommand com; //untuk mengkoneksikan database ke visual studio

        public string deletePemesanan(string IDPemesanan)
        {
            throw new NotImplementedException();
        }

        public List<DetailLokasi> DetailLokasi()
        {
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }
        public string editPemesanan(string IDPemesanan, string NamaCustomer)
        {
            throw new NotImplementedException();
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, int JumlahPemesanan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbp.Pemesanan values ('" + IDPemesanan + "','" + NamaCustomer + "','" + NoTelepon + "','" + JumlahPemesanan + "','" + IDLokasi + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }
    }
}

