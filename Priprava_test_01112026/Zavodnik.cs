namespace Priprava_test_01112026;

public class Zavodnik : IComparable<Zavodnik>
{
    private string? _startovniCislo;
    private string? _jmeno;
    private string? _prijmeni;
    private long _cas;

    public Zavodnik(string startovniCislo, string jmeno, long cas, string prijmeni)
    {
        StartovniCislo = startovniCislo;
        Jmeno = jmeno;
        Cas = cas;
        Prijmeni = prijmeni;
    }

    public string? StartovniCislo
    {
        get => _startovniCislo;
        set => _startovniCislo = value;
    }

    public string? Jmeno
    {
        get => _jmeno;
        set => _jmeno = value;
    }

    public long Cas
    {
        get => _cas;
        set => _cas = value;
    }

    public string? Prijmeni
    {
        get => _prijmeni;
        set => _prijmeni = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Zavodnik zavodnik) return false;

        return string.Equals(_startovniCislo, zavodnik._startovniCislo, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        if (_startovniCislo is null) return 0;

        return StringComparer.CurrentCultureIgnoreCase.GetHashCode(_startovniCislo);
    }

    public int CompareTo(Zavodnik? other)
    {
        if (other is null) return 1;

        int result = _cas.CompareTo(other._cas);
        if (result != 0) return result;

        result = string.Compare(_prijmeni, other.Prijmeni, StringComparison.OrdinalIgnoreCase);
        if (result != 0) return result;

        return string.Compare(_startovniCislo, other._startovniCislo, StringComparison.OrdinalIgnoreCase);
    }
}