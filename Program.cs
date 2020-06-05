public bool ValidarCedula(string cedula)
{
    int digito = 0;
    int digitoVerificador = 0;
    bool resultado = false;
    int[] multiplicadores = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
    int producto = 0;
    int suma = 0;

    if (cedula.Contains("-"))
        cedula = cedula.Replace("-","");

    _ = int.TryParse(cedula.Substring(cedula.Length - 1), out digitoVerificador);
   
    for (int i = 0; i < (cedula.Length - 1); i++)
    {
        _ = int.TryParse(cedula[i].ToString(), out digito);
        producto = digito * multiplicadores[i];
                
        if (producto >= 10)
            producto = (producto / 10) + (producto % 10);
            
        suma += producto;
    }

    if ((suma + digitoVerificador) % 10 == 0)
        resultado = true;

    return resultado;
}
