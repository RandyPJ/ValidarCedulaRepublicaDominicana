public bool CedulaValida(string cedula)
{
    bool resultado = false;

    if (string.IsNullOrEmpty(cedula) ||
        string.IsNullOrWhiteSpace(cedula))
        return resultado;

    int[] multiplicadores = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
    int verificador = 0;
    int suma = 0;

    if (cedula.Contains("-"))
        cedula = cedula.Replace("-","");

    _ = int.TryParse(cedula.Substring(cedula.Length - 1), out verificador);

    for (int i = 0; i < (cedula.Length - 1); i++)
    {
        _ = int.TryParse(cedula[i].ToString(), out int digito);
        int producto = digito * multiplicadores[i];
                
        if (producto >= 10)
            producto = (producto / 10) + (producto % 10);
            
        suma += producto;
    }

    if ((suma + verificador) % 10 == 0)
        resultado = true;

    return resultado;
}
