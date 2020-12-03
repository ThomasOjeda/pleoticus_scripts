using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class UpdateText : MonoBehaviour
{

    public TextMeshProUGUI texto;
    private string info;
    private string name;
    private List<Colecciones> listacolecciones = new List<Colecciones>();
    private int pagina;
    private int totalPaginas;



    public void updateName(string input)
    {
        name = input;
        StartCoroutine(GetText("https://diseno2020.herokuapp.com/api/actorOficina"));
    }

    //corrutina para hacer el get en la base y recuperar las oficinas por las que estuvo el empleado
    private IEnumerator GetText(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.Send();

        if (www.isError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            info = www.downloadHandler.text;
            limpiarHistorial();
            actualizarTablero(1);
        }
    }

    //Se encarga de hacer una limpieza del json que se recibe de la base de datos
    private void limpiarHistorial()
    {
        //Genero el arreglo con cada coleccion 
        string[] datos = info.Split('{');

        //Limpio la lista de las colecciones
        listacolecciones.Clear();
        listacolecciones = new List<Colecciones>();

        for (int i = datos.Length - 1; i >= 0; i--)
        {
            //si esta el nombre de usuario que busco lo uso
            if (datos[i].Contains(name))
            {
                Colecciones actual = new Colecciones();
                actual.oficina = datos[i].Split('"')[11];
                actual.entrada = acomodarFecha(datos[i].Split('"')[15]);
                listacolecciones.Add(actual);
            }
        }

        if (listacolecciones.Count > 0)
        {
            //Hago uso el 5 por el tamaño del monitor, para que se vea bien
            totalPaginas = listacolecciones.Count / 5;
            if (listacolecciones.Count % 5 != 0)
                totalPaginas++;
        }
    }

    //Se encarga de modificar lo que se muestra en el tablero
    private void actualizarTablero(int nuevaPagina)
    {
        //Si no hay historial 
        if (listacolecciones.Count <= 0)
        {
            texto.text = "No hay historial de un empleado llamado " + name;
        }
        //Si hay historial lo actualizo
        else
        {
            //Se elige cual es la nueva pagina
            if (nuevaPagina > totalPaginas)
            {
                //Vuelvo a la primer pagina
                pagina = 1;
            }
            else
            {
                if (nuevaPagina < 1)
                {
                    //Vuelvo a la ultima pagina
                    pagina = totalPaginas;
                }
                else
                {
                    pagina = nuevaPagina;
                }
            }

            int inicio = (pagina - 1) * 5;
            int fin;
            if (pagina == totalPaginas && listacolecciones.Count % 5 != 0)
                fin = inicio + listacolecciones.Count % 5;
            else
                fin = inicio + 5;

            string textoFuturo = "Historial del empleado " + name + "  ";
            for (int i = inicio; i < fin; i++)
            {
                textoFuturo = string.Concat(textoFuturo, " ", listacolecciones[i].oficina, " ", listacolecciones[i].entrada);
            }
            textoFuturo = string.Concat(textoFuturo, " Pagina ", pagina, "/", totalPaginas);
            texto.text = textoFuturo;
        }
    }

    //Se encarga de actualizar el tablero con la pagina siguiente
    public void paginaSiguiente()
    {
        if (listacolecciones.Count > 0)
        {
            actualizarTablero(pagina + 1);
        }
    }

    //Se encarga de actualizar el tablero con la pagina anterior
    public void paginaAnterior()
    {
        if (listacolecciones.Count > 0)
        {
            actualizarTablero(pagina - 1);
        }
    }

    //Paso del formato AAAA-MM-DD HH:MM:SS
    //Al formato DD/MM/AA HH:MM
    private string acomodarFecha(string fecha)
    {
        char[] arr = fecha.ToCharArray();
        string fechaFinal = arr[8] + arr[9] + "/" + arr[5] + arr[6] + "/" + arr[2] + arr[3] + " " + arr[11] + arr[12] + arr[13] + arr[14] + arr[15];
        return fechaFinal;
    }

    public class Colecciones
    {
        public string oficina;
        public string entrada;
        public string salida;
    }

}
