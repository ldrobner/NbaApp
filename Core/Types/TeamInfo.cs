namespace NbaApp.Core.Types;

public class TeamInfo {
    string Abbreviation { get; set; }
    string City { get; set; }
    string ShortName { get; set; }
    int Index { get; set; }
    string Division { get; set; }
    string Conference { get; set; }

    public TeamInfo(
        string abbreviation,
        string city,
        string shortName,
        int index,
        string division,
        string conference
    ) {
        Abbreviation = abbreviation;
        City = city;
        ShortName = shortName;
        Index = index;
        Division = division;
        Conference = conference;
    }
}