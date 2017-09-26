//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// GeneradorMazmorra.cs (26/09/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Generador no logico de mazmorras							\\
// Fecha Mod:		26/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Generador no logico de mazmorras</para>
	/// </summary>
	public class GeneradorMazmorra : MonoBehaviour 
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Largo de la mazmorra.</para>
		/// </summary>
		public int x = 15;								// Largo de la mazmorra
		/// <summary>
		/// <para>Altura de la mazmorra.</para>
		/// </summary>
		public int y = 15;								// Altura de la mazmorra
		/// <summary>
		/// <para>Semilla.</para>
		/// </summary>
		public int seed = 99;							// Semilla
		/// <summary>
		/// <para>Determina si la seed sera aleatoria.</para>
		/// </summary>
		public bool seedAleatoria = false;				// Determina si la seed sera aleatoria
		/// <summary>
		/// <para>Porcentaje de muros.</para>
		/// </summary>
		[Range(0, 100)] public int Muros = 50;			// Porcentaje de muros
		#endregion

		#region Variabes privadas
		/// <summary>
		/// <para>Mapa de la mazmorra.</para>
		/// </summary>
		private int[,] mazmorraMapa;					// Mapa de la mazmorra
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Inicializador de <see cref="GeneradorMazmorra"/>.</para>
		/// </summary>
		private void Start()// Inicializador de GeneradorMazmorra
		{
			// Creamos la mazmorra
			CrearMazmorra();
		}
		#endregion

		#region Actualizadores
		/// <summary>
		/// <para>Actualizador de <see cref="GeneradorMazmorra"/>.</para>
		/// </summary>
		private void Update()// Actualizador de GeneradorMazmorra
		{
			// Creamos la mazmorra
			if (Input.GetMouseButtonDown(0))
			{
				CrearMazmorra();
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Crear la mazmorra.</para>
		/// </summary>
		private void CrearMazmorra()// Crear la mazmorra
		{
			mazmorraMapa = new int[x, y];
			Procesar();
		}

		/// <summary>
		/// <para>Logica de la creacion de la mazmorra.</para>
		/// </summary>
		private void Procesar()// Logica de la creacion de la mazmorra
		{
			Random.InitState((seedAleatoria) ? Random.Range(int.MinValue, int.MaxValue) : seed);

			for (int n = 0; n < x; n++)// Filas
			{
				for (int i = 0; i < y; i++)// Columnas
				{
					if (n == 0 || n == (x - 1) || i == 0 || i == (y - 1))
					{
						mazmorraMapa[n, i] = 1;
					}
					else
					{
						int probabilidad = Random.Range(0, 100);
						if (probabilidad < Muros)
						{
							mazmorraMapa[n, i] = 1;
						}
						else
						{
							mazmorraMapa[n, i] = 0;
						}
					}
				}
			}
		}

		/// <summary>
		/// <para>Dibuja la mazmorra.</para>
		/// </summary>
		private void OnDrawGizmos()// Dibuja la mazmorra
		{
			if (mazmorraMapa != null)
			{
				for (int n = 0; n < x; n++)// Filas
				{
					for (int i = 0; i < y; i++)// Columnas
					{
						Gizmos.color = (mazmorraMapa[n, i] == 0) ? Color.white : Color.black;
						Gizmos.DrawCube(new Vector3(n, i, 0f), new Vector3(0.9f, 0.9f, 0.9f));
					}
				}
			}
		}
		#endregion
	}
}