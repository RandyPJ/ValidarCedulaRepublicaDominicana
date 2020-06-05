public bool ValidarCedula(string cedula)
{
    bool resultado = false;
    int[] multiplicadores = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
    int digitoVerificador = 0;
    int suma = 0;

    if (cedula.Contains("-"))
        cedula = cedula.Replace("-","");

    _ = int.TryParse(cedula.Substring(cedula.Length - 1), out digitoVerificador);

    int digito = 0;
    for (int i = 0; i < (cedula.Length - 1); i++)
    {
        _ = int.TryParse(cedula[i].ToString(), out digito);
        int producto = digito * multiplicadores[i];
                
        if (producto >= 10)
            producto = (producto / 10) + (producto % 10);
            
        suma += producto;
    }

    if ((suma + digitoVerificador) % 10 == 0)
        resultado = true;

    return resultado;
}
