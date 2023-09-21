using DMD.Domain.Models;

namespace DMD.Domain.DataStores
{
    public class BandDataStore
    {
        public List<Band> Bands { get; set; } = new List<Band>();

        public BandDataStore()
        {
            Bands.AddRange(new List<Band>()
            {
                new Band()
                {
                    Name = "Metallica",
                    Genre = "Thrash Metal",
                    Members = new Dictionary<string, BandMember>()
                    {
                        ["James Hetfield"] = new BandMember
                        {
                            Instrument = "Guitar/Vocals",
                        }
                    },

                    Albums = new Dictionary<string, Album>()
                    {
                        ["Kill 'em All"] = new Album()
                        {
                            Name = "Kill 'em All",
                            Songs = new Dictionary<string, Song>()
                            {
                                ["Hit The Lights"] = new Song()
                                {
                                    Name = "Hit The Lights",
                                    Length = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(17)),
                                },
                                ["The Four Horsemen"] = new Song()
                                {
                                    Name = "The Four Horsemen",
                                    Length = TimeSpan.FromMinutes(7).Add(TimeSpan.FromSeconds(13)),
                                },
                                ["Motorbreath"] = new Song()
                                {
                                    Name = "Motorbreath",
                                    Length = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(8)),
                                },
                                ["Jump in the Fire"] = new Song()
                                {
                                    Name = "Jump in the Fire",
                                    Length = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(42)),
                                },
                                ["(Anesthesia) Pulling Teeth"] = new Song()
                                {
                                    Name = "(Anesthesia) Pulling Teeth",
                                    Length = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(15)),
                                },
                                ["Whiplash"] = new Song()
                                {
                                    Name = "Whiplash",
                                    Length = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(10)),
                                },
                                ["Phantom Lord"] = new Song()
                                {
                                    Name = "Phantom Lord",
                                    Length = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(1)),
                                },
                                ["No Remorse"] = new Song()
                                {
                                    Name = "No Remorse",
                                    Length = TimeSpan.FromMinutes(6).Add(TimeSpan.FromSeconds(26)),
                                },
                                ["Seek & Destroy"] = new Song()
                                {
                                    Name = "Seek & Destroy",
                                    Length = TimeSpan.FromMinutes(6).Add(TimeSpan.FromSeconds(55)),
                                },
                                ["Metal Militia"] = new Song()
                                {
                                    Name = "Metal Militia",
                                    Length = TimeSpan.FromMinutes(5).Add(TimeSpan.FromSeconds(10)),
                                }
                            }
                        }
                    }
                }
            });
        }
    }
}