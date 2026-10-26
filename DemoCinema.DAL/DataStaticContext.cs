using DemoCinema.DAL.Entities;

namespace DemoCinema.DAL
{
    public class DataStaticContext
    {
        #region Movie
        internal List<MovieEntity> Movies = [
            new MovieEntity
            {
                Id = 1,
                Title = "Begotten",
                ReleaseDate = new DateTime(1989, 10, 24),
                Director = "E. Elias|Merhige",
                Genres = ["Horreur", "Expérimental", "Fantasy"],
                Desc = "Une œuvre muette et surréaliste en noir et blanc ultra-contrasté, illustrant la mort de Dieu et la naissance de la Terre-Mère.",
                Rating = 3.5
            },
            new MovieEntity
            {
                Id = 2,
                Title = "L'Empereur Tomate-Cru (Tomato Kechappu Kōtei)",
                ReleaseDate = new DateTime(1971, 01, 01),
                Director = "Shūji|Terayama",
                Genres = ["Expérimental", "Satire", "Drame"],
                Desc = "Un moyen-métrage avant-gardiste japonais où les enfants renversent les adultes et prennent le contrôle de la société.",
                Rating = 4.5
            },
            new MovieEntity
            {
                Id = 3,
                Title = "Le Sang d'un poète",
                ReleaseDate = new DateTime(1932, 01, 20),
                Director = "Jean|Cocteau",
                Genres = ["Avant-garde", "Fantastique"],
                Desc = "Le premier film de Cocteau. Un voyage onirique à travers l'esprit d'un artiste, un miroir traversé et des statues qui parlent.",
                Rating = 2
            },
            new MovieEntity
            {
                Id = 4,
                Title = "La Cicatrice de la vieille dette (Aranyer Din Ratri)",
                ReleaseDate = new DateTime(1970, 04, 15),
                Director = "Satyajit|Ray",
                Genres = ["Drame"],
                Desc = "Quatre citadins de Calcutta partent se perdre dans une forêt tribale pour fuir la modernité. Un chef-d'œuvre méconnu du cinéma bengali.",
                Rating = 4
            },
            new MovieEntity
            {
                Id = 5,
                Title = "Decoder",
                ReleaseDate = new DateTime(1984, 02, 18),
                Director = "Klaus|Muscha",
                Genres = ["Science-Fiction", "Cyberpunk", "Underground"],
                Desc = "Film ouest-allemand basé sur les écrits de William S. Burroughs. Un hacker découvre que la musique industrielle peut provoquer des émeutes contre le contrôle mental corporatiste.",
                Rating = 1.5
            },
            new MovieEntity
            {
                Id = 6,
                Title = "Monty Python et le Sacré Graal (Monty Python and the Holy Grail)",
                ReleaseDate = new DateTime(1975, 04, 03),
                Director = "Terry|Gilliam",
                Genres = ["Comédie", "Parodie", "Aventure"],
                Desc = "Une parodie burlesque et culte de la quête du Roi Arthur, impliquant des noix de coco, un lapin tueur et des chevaliers qui disent 'Ni !'.",
                Rating = 5
            }
        ];
        internal int NextMovieId = 7;
        #endregion

        #region Screening
        internal List<ScreeningEntity> Screenings = [
            new ScreeningEntity {
                Id = 1,
                Schedule = new DateTime(2026, 8, 1),
                Duration = 180,
                MovieId = 6,
                IsCancel = false
            },
            new ScreeningEntity {
                Id = 2,
                Schedule = new DateTime(2026, 9, 12),
                Duration = 150,
                MovieId = 2,
                IsCancel = false
            },
            new ScreeningEntity {
                Id = 4,
                Schedule = new DateTime(2027, 1, 1),
                Duration = 210,
                MovieId = 6,
                IsCancel = false
            },
        ];
        internal int NextScreeningId = 5;
        #endregion

        #region Member
        internal List<MemberEntity> Members = [
            new MemberEntity {
                Id = 1,
                Email = "della@test",
                BirthDate = new DateTime(1989, 8, 13),
                FirstName = "Della",
                LastName = "Duck",
                Username = "MoonDuck",
                Role = "Admin",
                HashPassword = "AQAAAAIABJPgAAAAEHPleF6HzjqtKQHzydKSObvOcBZ1USqAhjMPW9THCPyDBJSqyb6tW+SIE/h2LlXBdw=="
            },
            new MemberEntity {
                Id = 2,
                Email = "donald@test",
                BirthDate = new DateTime(1989, 8, 13),
                FirstName = null,
                LastName = null,
                Username = "NotDonald",
                Role = "User",
                HashPassword = "AQAAAAIABJPgAAAAEPia4FtSQvuvSemvdgadCnjTFsy4NNfAjK6wjhdF7Sa2Wy57YFWAwgVBtcDksYtiZQ=="
            },
            new MemberEntity {
                Id = 3,
                Email = "zaza@test",
                BirthDate = new DateTime(2013, 10, 2),
                FirstName = "Zaza",
                LastName = "Vanderquack",
                Username = "TacticalPancake",
                Role = "Modo",
                HashPassword = "AQAAAAIABJPgAAAAEF81uEAcV8dA5TplSQYHQFcJmH3hB4tDRC6kW0M0g6LzKOBB2x+WoDFj7blMejB2+Q=="
            },
            new MemberEntity {
                Id = 4,
                Email = "balthy@test",
                BirthDate = new DateTime(1949, 7, 8),
                FirstName = "Balthazar",
                LastName = "Picsou",
                Username = "MonsieurBalthazar",
                Role = "User",
                HashPassword = "AQAAAAIABJPgAAAAEGsKsq59hi5adx8sghZxZAiXFywcfvgUwqMTx5WVCw4IzVLIH1dz6TYNMsXC2cxTjw=="
            },
            new MemberEntity {
                Id = 5,
                Email = "lena@test",
                BirthDate = new DateTime(2009, 2, 22),
                FirstName = "Lena",
                LastName = "De Sortilège",
                Username = "ShadowShirley",
                Role = "User",
                HashPassword = "AQAAAAIABJPgAAAAEMBp4BbCGQdWhzvBh7wtSi9zJoR9qLhiR7jkEIEIveYyz/7UB5Co/w7T/dsgCc3KsQ=="
            }
        ];
        internal int NextMemberId = 7;
        #endregion
    }
}
