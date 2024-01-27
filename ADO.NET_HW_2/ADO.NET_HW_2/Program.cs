namespace ADO.NET_HW_2
{
    using ADO.NET_HW_2.ChroniclesOfAscents;
    using ADO.NET_HW_2.Library;
    using ADO.NET_HW_2.Note;
    using Microsoft.Data.SqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

    internal class Program
    {
        static void Main(string[] args)
        {
            
            DBManipulation dBManipulation = new DBManipulation();
            var connectserver = dBManipulation.GetConnectionServer();// ONLY SERVER connect
            #region ChroniclesOfAscents
            using (connectserver)
            {
                CRUD_use_sp addinfo = new CRUD_use_sp(connectserver);
                GeneralOperations generalOperations = new GeneralOperations(connectserver);
                connectserver.Open();


                SqlCommand selectdb = new SqlCommand("USE ChroniclesOfAscents", connectserver);//Use DB
                selectdb.ExecuteNonQuery();

                addinfo.UpdatedGroup("Group 4", 4);

                addinfo.AddGroup("Group 1");
                addinfo.AddGroup("Group 2");
                addinfo.AddGroup("Group 3");
                addinfo.AddMountaineer(new List<Mountaineer> {
                  new Mountaineer("Vasya", "Adress", 1),
                  new Mountaineer("Petya", "Adress 1", 1),
                  new Mountaineer("Dusya", "Adress 2", 1),
                  new Mountaineer("Antony", "Adress", 2),
                  new Mountaineer("Ray", "Adress 1", 2),
                  new Mountaineer("Bradbury", "Adress 2",2),
                   new Mountaineer("Jonh", "Adress", 3),
                  new Mountaineer("Emaly", "Adress 1", 3),
                  new Mountaineer("Rumpelshtilchen", "Adress 2",3)

              });

                addinfo.AddMountain("Mountian", 8600, "Country");
                addinfo.AddMountain("Mountian 1", 3500, "Country 1");
                addinfo.AddMountain("Mountian 2", 5200, "Country 2");
                addinfo.AddClimbing(1, 1, "2023-01-28", "2023-03-05");
                addinfo.AddClimbing(1, 1, "2022-01-28", "2022-03-05");
                addinfo.AddClimbing(1, 2, "2024-01-28", "2024-02-05");
                addinfo.AddClimbing(2, 2, "2024-02-28", "2024-05-05");
                addinfo.AddClimbing(3, 3, "2024-02-28", "2024-05-05");

                generalOperations.GetListGroup();
                generalOperations.GetСlimbersRangeDate("2023-01-20", "2024-02-28");
                generalOperations.GetCountClimbing();
                generalOperations.GetCountOnMountaing();
                generalOperations.UpdateInfoClimbing(1, 1, "2023-01-28", "2023-02-05", true);
                generalOperations.AddNewGroup("new group", 1, "2022-05-23");



            }
            #endregion

            #region Library
            using (connectserver)
            {
                LibraryDB libraryDB = new LibraryDB(connectserver);
                Reader reader = new Reader("Alex", "Finch", "268-33-85");
                connectserver.Open();
                SqlCommand selectdb = new SqlCommand("USE MyLibrary", connectserver);//Use DB
                selectdb.ExecuteNonQuery();
                //libraryDB.AddAuthor(new Author ("Author name","Lname"));
                //libraryDB.AddABook(new Book("Any","2024-01-27",3,2));
                //libraryDB.AddReader(reader);
                //libraryDB.RantABook(3,4);
                //libraryDB.RefundBook(3, 4);
                //libraryDB.GetListBook();
                //libraryDB.GetListAuthor();
                //libraryDB.GetListReader();
            }
            #endregion

            #region Note


            using (connectserver)
            {
                NoteDB noteDB = new NoteDB(connectserver);
                connectserver.Open();
                SqlCommand selectdb = new SqlCommand("USE ToDoList", connectserver);//Use DB
                selectdb.ExecuteNonQuery();
                noteDB.AddUser(new User { Name = "My Name" });
                noteDB.AddnewNote(new Note.Note { Title = "Title", Description = "description", UserId = 1 },
                   new Note.Note { Title = "Title 1", Description = "description 1", UserId = 1 });
                noteDB.GetListNote(1);
                noteDB.UpdateNote(new Note.Note { Title = "Update", Description = "update description",Id=2, UserId = 1 });
                noteDB.DeleteListNote(1);

            }
            #endregion





        }
    }
}
