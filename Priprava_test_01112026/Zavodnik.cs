namespace Priprava_test_01112026;

public class Zavodnik : IComparable<Zavodnik>
{
    private string _startovniCislo;
    private string _jmeno;
    private string _prijmeni;
    private long _cas;

    public Zavodnik(string startovniCislo, string jmeno, long cas, string prijmeni)
    {
        StartovniCislo = startovniCislo;
        Jmeno = jmeno;
        Cas = cas;
        Prijmeni = prijmeni;
    }

    public string StartovniCislo
    {
        get => _startovniCislo;
        set => _startovniCislo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Jmeno
    {
        get => _jmeno;
        set => _jmeno = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Prijmeni
    {
        get => _prijmeni;
        set => _prijmeni = value ?? throw new ArgumentNullException(nameof(value));
    }

    public long Cas
    {
        get => _cas;
        set => _cas = value;
    }
    

    public override bool Equals(object? obj)
    {
        //Pokud objekt není Zavodnik, vrátí false 
        if (obj is not Zavodnik zavodnik) return false;

        //V tento moment je jasné, že objekt obj je Zavodnik a pojmenoval jsem to zavodnik 
        
        //Porovnám dva stringy (toto a příchozí startovací číslo)
        return string.Equals(_startovniCislo, zavodnik._startovniCislo, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        //Každý null objekt dostane hash 0 - proto v HashSetu smí být PRÁVĚ JEDEN null objekt
        if (_startovniCislo is null) return 0;

        //Vratí hash kód ze startovního čísla, ale s ignore case (ten zápis je otřesnej)
        return StringComparer.CurrentCultureIgnoreCase.GetHashCode(_startovniCislo);
    }

    public int CompareTo(Zavodnik? other)
    {
        //Pokud je vstupní objekt null, pak objekt "this" (ten, který volá) je větší
        if (other is null) return 1;

        //První porovnání s nejvyšší prioritou - pokud se časy rovnají pokračujeme 
        int result = _cas.CompareTo(other._cas);
        if (result != 0) return result;

        //Druhé porovnání s nižší prioritou - nastane jen pokud jsou časy stejné, a pokud se i oni rovnají, pak pokračujeme
        result = string.Compare(_prijmeni, other.Prijmeni, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        //Finální rozseknutí, které potvrdí, zda dva objekty nejsou opravdu stejné (vždy se jedná o primární klíč té třídy)
        return string.Compare(_startovniCislo, other._startovniCislo, StringComparison.OrdinalIgnoreCase);
    }
}