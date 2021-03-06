using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TeaMVC.Models;

namespace TeaMVC.Models


{
    public class SampleData : DropCreateDatabaseIfModelChanges<TeaEntities>
    {
        static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void Seed(TeaEntities context)
        {
            var Types = new List<Type>
            {
                new Type { Name = "Phổ biến" },
                new Type { Name = "Châu trâu thượng hạng" },
                new Type { Name = "Mật ong" },
                new Type { Name = "Ít đường" },
                new Type { Name = "Giảm béo" },
                new Type { Name = "Tăng cân" },
                new Type { Name = "Loại cấm" },
                new Type { Name = "Loại ngon" },
                new Type { Name = "Loại đắt tiền" },
                new Type { Name = "Loại đặc biệt" }
            };

            var Sups = new List<Sup>
            {
                new Sup { Name = "Aaron Copland & London Symphony Orchestra" },
                new Sup { Name = "Aaron Goldberg" },
                new Sup { Name = "AC/DC" },
                new Sup { Name = "Accept" },
                new Sup { Name = "Adrian Leaper & Doreen de Feis" },
                new Sup { Name = "Aerosmith" },
                new Sup { Name = "Aisha Duo" },
                new Sup { Name = "Alanis Morissette" },
                new Sup { Name = "Alberto Turco & Nova Schola Gregoriana" },
                new Sup { Name = "Alice In Chains" },
                new Sup { Name = "Amy Winehouse" },
                new Sup { Name = "Anita Ward" },
                new Sup { Name = "Antônio Carlos Jobim" },
                new Sup { Name = "Apocalyptica" },
                new Sup { Name = "Audioslave" },
                new Sup { Name = "Barry Wordsworth & BBC Concert Orchestra" },
                new Sup { Name = "Berliner Philharmoniker & Hans Rosbaud" },
                new Sup { Name = "Berliner Philharmoniker & Herbert Von Karajan" },
                new Sup { Name = "Billy Cobham" },
                new Sup { Name = "Black Label Society" },
                new Sup { Name = "Black Sabbath" },
                new Sup { Name = "Boston Symphony Orchestra & Seiji Ozawa" },
                new Sup { Name = "Britten Sinfonia, Ivor Bolton & Lesley Garrett" },
                new Sup { Name = "Bruce Dickinson" },
                new Sup { Name = "Buddy Guy" },
                new Sup { Name = "Caetano Veloso" },
                new Sup { Name = "Cake" },
                new Sup { Name = "Calexico" },
                new Sup { Name = "Cássia Eller" },
                new Sup { Name = "Chic" },
                new Sup { Name = "Chicago Symphony Orchestra & Fritz Reiner" },
                new Sup { Name = "Chico Buarque" },
                new Sup { Name = "Chico Science & Nação Zumbi" },
                new Sup { Name = "Choir Of Westminster Abbey & Simon Preston" },
                new Sup { Name = "Chris Cornell" },
                new Sup { Name = "Christopher O'Riley" },
                new Sup { Name = "Cidade Negra" },
                new Sup { Name = "Cláudio Zoli" },
                new Sup { Name = "Creedence Clearwater Revival" },
                new Sup { Name = "David Coverdale" },
                new Sup { Name = "Deep Purple" },
                new Sup { Name = "Dennis Chambers" },
                new Sup { Name = "Djavan" },
                new Sup { Name = "Donna Summer" },
                new Sup { Name = "Dread Zeppelin" },
                new Sup { Name = "Ed Motta" },
                new Sup { Name = "Edo de Waart & San Francisco Symphony" },
                new Sup { Name = "Elis Regina" },
                new Sup { Name = "English Concert & Trevor Pinnock" },
                new Sup { Name = "Eric Clapton" },
                new Sup { Name = "Eugene Ormandy" },
                new Sup { Name = "Faith No More" },
                new Sup { Name = "Falamansa" },
                new Sup { Name = "Foo Fighters" },
                new Sup { Name = "Frank Zappa & Captain Beefheart" },
                new Sup { Name = "Fretwork" },
                new Sup { Name = "Funk Como Le Gusta" },
                new Sup { Name = "Gerald Moore" },
                new Sup { Name = "Gilberto Gil" },
                new Sup { Name = "Godsmack" },
                new Sup { Name = "Gonzaguinha" },
                new Sup { Name = "Göteborgs Symfoniker & Neeme Järvi" },
                new Sup { Name = "Guns N' Roses" },
                new Sup { Name = "Gustav Mahler" },
                new Sup { Name = "Incognito" },
                new Sup { Name = "Iron Maiden" },
                new Sup { Name = "James Levine" },
                new Sup { Name = "Jamiroquai" },
                new Sup { Name = "Jimi Hendrix" },
                new Sup { Name = "Joe Satriani" },
                new Sup { Name = "Jorge Ben" },
                new Sup { Name = "Jota Quest" },
                new Sup { Name = "Judas Priest" },
                new Sup { Name = "Julian Bream" },
                new Sup { Name = "Kent Nagano and Orchestre de l'Opéra de Lyon" },
                new Sup { Name = "Kiss" },
                new Sup { Name = "Led Zeppelin" },
                new Sup { Name = "Legião Urbana" },
                new Sup { Name = "Lenny Kravitz" },
                new Sup { Name = "Les Arts Florissants & William Christie" },
                new Sup { Name = "London Symphony Orchestra & Sir Charles Mackerras" },
                new Sup { Name = "Luciana Souza/Romero Lubambo" },
                new Sup { Name = "Lulu Santos" },
                new Sup { Name = "Marcos Valle" },
                new Sup { Name = "Marillion" },
                new Sup { Name = "Marisa Monte" },
                new Sup { Name = "Martin Roscoe" },
                new Sup { Name = "Maurizio Pollini" },
                new Sup { Name = "Mela Tenenbaum, Pro Musica Prague & Richard Kapp" },
                new Sup { Name = "Men At Work" },
                new Sup { Name = "Metallica" },
                new Sup { Name = "Michael Tilson Thomas & San Francisco Symphony" },
                new Sup { Name = "Miles Davis" },
                new Sup { Name = "Milton Nascimento" },
                new Sup { Name = "Mötley Crüe" },
                new Sup { Name = "Motörhead" },
                new Sup { Name = "Nash Ensemble" },
                new Sup { Name = "Nicolaus Esterhazy Sinfonia" },
                new Sup { Name = "Nirvana" },
                new Sup { Name = "O Terço" },
                new Sup { Name = "Olodum" },
                new Sup { Name = "Orchestra of The Age of Enlightenment" },
                new Sup { Name = "Os Paralamas Do Sucesso" },
                new Sup { Name = "Ozzy Osbourne" },
                new Sup { Name = "Page & Plant" },
                new Sup { Name = "Paul D'Ianno" },
                new Sup { Name = "Pearl Jam" },
                new Sup { Name = "Pink Floyd" },
                new Sup { Name = "Queen" },
                new Sup { Name = "R.E.M." },
                new Sup { Name = "Raul Seixas" },
                new Sup { Name = "Red Hot Chili Peppers" },
                new Sup { Name = "Roger Norrington, London Classical Players" },
                new Sup { Name = "Royal Philharmonic Orchestra & Sir Thomas Beecham" },
                new Sup { Name = "Rush" },
                new Sup { Name = "Santana" },
                new Sup { Name = "Scholars Baroque Ensemble" },
                new Sup { Name = "Scorpions" },
                new Sup { Name = "Sergei Prokofiev & Yuri Temirkanov" },
                new Sup { Name = "Sir Georg Solti & Wiener Philharmoniker" },
                new Sup { Name = "Skank" },
                new Sup { Name = "Soundgarden" },
                new Sup { Name = "Spyro Gyra" },
                new Sup { Name = "Stevie Ray Vaughan & Double Trouble" },
                new Sup { Name = "Stone Temple Pilots" },
                new Sup { Name = "System Of A Down" },
                new Sup { Name = "Temple of the Dog" },
                new Sup { Name = "Terry Bozzio, Tony Levin & Steve Stevens" },
                new Sup { Name = "The 12 Cellists of The Berlin Philharmonic" },
                new Sup { Name = "The Black Crowes" },
                new Sup { Name = "The Cult" },
                new Sup { Name = "The Doors" },
                new Sup { Name = "The King's Singers" },
                new Sup { Name = "The Police" },
                new Sup { Name = "The Posies" },
                new Sup { Name = "The Rolling Stones" },
                new Sup { Name = "The Who" },
                new Sup { Name = "Tim Maia" },
                new Sup { Name = "Ton Koopman" },
                new Sup { Name = "U2" },
                new Sup { Name = "UB40" },
                new Sup { Name = "Van Halen" },
                new Sup { Name = "Various Sups" },
                new Sup { Name = "Velvet Revolver" },
                new Sup { Name = "Vinícius De Moraes" },
                new Sup { Name = "Wilhelm Kempff" },
                new Sup { Name = "Yehudi Menuhin" },
                new Sup { Name = "Yo-Yo Ma" },
                new Sup { Name = "Zeca Pagodinho" }
            };

            Random r = new Random();

            new List<Tea>
            {

                new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },
                  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" },  new Tea { Title = "Chân châu trà chanh", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu dâu tây", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu thịt gà", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu mắm tôm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu canh cua", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu nước mắm", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đỏ", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu đậu đen", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua01.jpg" },
                new Tea { Title = "Chân châu khoai lang", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua09.jpg" },
                new Tea { Title = "Chân châu ngô", Type = Types[r.Next(0,Types.Count-1)], Price = 8.99M, Sup = Sups[r.Next(0,Sups.Count-1)], TeaArtUrl = "/Content/Images/Product/trasua10.jpg" }
            }.ForEach(a => context.Teas.Add(a));
        }
    }
}