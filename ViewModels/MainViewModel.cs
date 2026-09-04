using System.Collections.ObjectModel;
using System.Drawing.Imaging.Effects;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

public class MainViewModel
{
    public ObservableCollection<Rune> AllRunes { get; } = [];
    public ObservableCollection<OwnedRune> OwnedRunes { get; } = [];
    public ObservableCollection<Runeword> AllRunewords { get; } = [];
    public ObservableCollection<Runeword> AvailableRunewords { get; } = [];
    public ICommand AddRuneCommand { get; }
    public ICommand ClearInventoryCommand { get; }

    public MainViewModel()
    {
        AddRuneCommand = new RelayCommand<Rune>(AddRune);
        ClearInventoryCommand = new RelayCommand(ClearInventory);

        LoadRunes();
        LoadRunewords();
    }

    private void LoadRunes()
    {
        var runes = new List<Rune>
        {
            new Rune { Name = "BOR", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "KLY", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "CIM", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "COL", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "DOL", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "DOS", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "ODO", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "OGI", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "PYD", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "SAK", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "SIL", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "SIV", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "TRU", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "VIN", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "ZER", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "ZOB", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "ZOL", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "MON", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "COS", ImagePath = "/Views/Images/blankRune.png" },
            new Rune { Name = "KRA", ImagePath = "/Views/Images/blankRune.png" }
        };

        foreach (var rune in runes)
        {
            AllRunes.Add(rune);
        }
    }
    private void LoadRunewords()
    {
        var runewords = new List<Runeword>
        {
            // Dyad runewords
            new Runeword {Name = "Blood Bath", Runes = new List<Rune> {GetRune("BOR"), GetRune("KLY")}, Effects = "Piercing attacks have a chance to apply bleed. (Varies depending on RuneLvls)"},
            new Runeword {Name = "Magic Focus", Runes = new List<Rune> {GetRune("BOR"), GetRune("MON")}, Effects = "Increases ability power if there is only one enemy. (Varies depending on RuneLvls)"},
            new Runeword {Name = "Toxic Cloud", Runes = new List<Rune> {GetRune("BOR"), GetRune("TRU")}, Effects = "Poison applies on all enemies."},
            new Runeword {Name = "Void Presence", Runes = new List<Rune> {GetRune("CIM"), GetRune("ODO")}, Effects = "Using a shadow talent heals for a percent of the maximum health. (Varies depending on RuneLvls)"},
            new Runeword {Name = "Arch Mage", Runes = new List<Rune> {GetRune("COS"), GetRune("MON")}, Effects = "Maximum mana increased by 20 for every active talent. "},
            new Runeword {Name = "Ice Nova", Runes = new List<Rune> {GetRune("DOL"), GetRune("PYD")}, Effects = "20% chance to cast Ice Nova when using an ice talent "},
            new Runeword {Name = "Deep Freeze", Runes = new List<Rune> {GetRune("DOL"), GetRune("SIV")}, Effects = "Ice damage reduces enemy armor."},
            new Runeword {Name = "Fire Eater", Runes = new List<Rune> {GetRune("DOS"), GetRune("OGI")}, Effects = "Burn damage heals you instead."},
            new Runeword {Name = "Secrets", Runes = new List<Rune> {GetRune("DOS"), GetRune("ZOL")}, Effects = "The Secret icons rotates."},
            new Runeword {Name = "Healing Rain", Runes = new List<Rune> {GetRune("KRA"), GetRune("ODO")}, Effects = "Healing is increased. (Varies depending on RuneLvls)"},
            new Runeword {Name = "Fire Nova", Runes = new List<Rune> {GetRune("OGI"), GetRune("PYD")}, Effects = "20% chance to cast Fire Nova when using a fire talent."},
            new Runeword {Name = "Spikes on the Butt", Runes = new List<Rune> {GetRune("SIL"), GetRune("COL")}, Effects = "Your thorns damage hits one more random enemy."},

            // Triad runewords
            new Runeword {Name = "Deep Wounds", Runes = new List<Rune> {GetRune("BOR"), GetRune("KLY"), GetRune("ZER")}, Effects = "Bleed applies on bleed resistant enemies."},
            new Runeword {Name = "Magic Spread", Runes = new List<Rune> {GetRune("CIM"), GetRune("DOL"), GetRune("SIV")}, Effects = "Poison attacks apply vulnerability."},
            new Runeword {Name = "Darkness", Runes = new List<Rune> {GetRune("CIM"), GetRune("MON"), GetRune("SAK")}, Effects = "Increases ABILITY POWER by x% for each enemy (Varies depending on RuneLvls)"},
            new Runeword {Name = "Soul Healing", Runes = new List<Rune> {GetRune("COS"), GetRune("DOS"), GetRune("ODO")}, Effects = "Improves critical shadow damage (Varies depending on RuneLvls)"},
            new Runeword {Name = "Arms", Runes = new List<Rune> {GetRune("COS"), GetRune("SIL"), GetRune("VIN")}, Effects = "Healing damage restores mana (Varies depending on RuneLvls)"},
            new Runeword {Name = "Mind", Runes = new List<Rune> {GetRune("COS"), GetRune("MON"), GetRune("VIN")}, Effects = "(Mind * No stacked effect) Staves have 1 additional attack"},
            new Runeword {Name = "Eyes", Runes = new List<Rune> {GetRune("COS"), GetRune("VIN"), GetRune("ZER")}, Effects = "(Arms * No stacked effect) Swords have 1 additional attack"},
            new Runeword {Name = "Magic Aura", Runes = new List<Rune> {GetRune("DOS"), GetRune("MON"), GetRune("ZOB")}, Effects = "(Eyes * No stacked effect) Bows have 1 additional attack"},
            new Runeword {Name = "Holy Right", Runes = new List<Rune> {GetRune("KRA"), GetRune("SIV"), GetRune("VIN")}, Effects = "AP increases by an amount per armor."},
            new Runeword {Name = "Of the Fittest", Runes = new List<Rune> {GetRune("MON"), GetRune("SIL"), GetRune("ZER")}, Effects = "x% chance to recast a talent (Varies depending on RuneLvls)"},
            new Runeword {Name = "Vigor", Runes = new List<Rune> {GetRune("ODO"), GetRune("PYD"), GetRune("ZOB")}, Effects = "Holy Spells have a chance to reset their cooldowns after use. (Varies depending on RuneLvls)"},
            new Runeword {Name = "Protection", Runes = new List<Rune> {GetRune("PYD"), GetRune("SAK"), GetRune("ZOB")}, Effects = "Increases maximum health (Varies depending on RuneLvls)"},
            new Runeword {Name = "Venom", Runes = new List<Rune> {GetRune("BOR"), GetRune("SAK"), GetRune("TRU")}, Effects = "Positive effects last more turns (Varies depending on RuneLvls)"},
            new Runeword {Name = "Mastermind", Runes = new List<Rune> {GetRune("DOS"), GetRune("MON"), GetRune("ZOL")}, Effects = "Fireball and Smite are considered Curses"},
            new Runeword {Name = "Cursed", Runes = new List<Rune> {GetRune("OGI"), GetRune("CIM"), GetRune("SIV")}, Effects = "Chance to gain protection for 5 turns when entering a room (Varies depending on RuneLvls)"}
        };

        foreach (var runeword in runewords)
        {
            AllRunewords.Add(runeword);
        }
    }

    private Rune GetRune(string name)
    {
        var rune = AllRunes.FirstOrDefault(r => r.Name == name) 
        ?? throw new Exception($"Rune '{name}' kunde inte hittas.");
        
        return rune;
    }

    private void AddRune(Rune? rune)
    {
        if (rune == null) return;

        var ownedRune = OwnedRunes.FirstOrDefault(x => x.Rune?.Name == rune.Name);

        if (ownedRune == null)
        {
            OwnedRunes.Add(new OwnedRune
            {
                Rune = rune,
                Amount = 1
            });
        }
        else ownedRune.Amount++;

        UpdateAvailableRunewords();
    }

    private void ClearInventory()
    {
        OwnedRunes.Clear();
        AvailableRunewords.Clear();
    }

    private bool CanCreate(Runeword runeword)
    {
        var requiredRunes = runeword.Runes
            .GroupBy(r => r.Name)
            .ToDictionary(
                group => group.Key,
                group => group.Count()
            );

        foreach (var requiredRune in requiredRunes)
        {
            var ownedRune = OwnedRunes.FirstOrDefault(x => x.Rune?.Name == requiredRune.Key);

            if (ownedRune == null) return false;

            if (ownedRune.Amount < requiredRune.Value) return false;
        }

        return true;
    }

    private void UpdateAvailableRunewords()
    {
        AvailableRunewords.Clear();

        foreach (var runeword in AllRunewords)
        {
            if (CanCreate(runeword)) AvailableRunewords.Add(runeword);
        }
    }
}