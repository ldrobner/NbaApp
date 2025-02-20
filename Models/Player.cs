namespace NbaApp.Models;

public class Player {

    private Dictionary<string, Dictionary<string, int>> totalsBySeason;

    public Player() {}

    public Dictionary<string, Dictionary<string, int>> getTotals() {
        return this.totalsBySeason;
    }

    public Dictionary<string, int> getTotals(string season) {
        if(!this.totalsBySeason.ContainsKey(season)) {
            throw new Exception($"{season} is not a value season."); 
        }
        return this.totalsBySeason[season];
    }

}