using System;
using System.IO;
using System.Windows;

public class FileHelp
{
	public static bool checkCreateFile(string path)
	{
		bool flag = !File.Exists(path);
		if (flag)
		{
			try
			{
				using (FileStream fileStream = File.Create(path))
				{
					fileStream.Close();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an issue while trying to create a file...Please close Celery and run as an administrator", "", MessageBoxButton.OK);
				return false;
			}
		}
		return true;
	}

	public static bool createFileText(string filepath, string content)
	{
		try
		{
			File.CreateText(filepath);
			try
			{
				File.WriteAllText(filepath, content);
				return true;
			}
			catch (Exception ex)
			{
			}
		}
		catch (Exception ex2)
		{
		}
		return false;
	}

	public static bool checkCreateFile(string path, string defaultValue)
	{
		bool flag = File.Exists(path);
		bool result;
		if (flag)
		{
			result = true;
		}
		else
		{
			FileHelp.checkCreateFile(path);
			try
			{
				File.WriteAllText(path, defaultValue);
				result = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an issue while trying to write to a file...Please close Celery and run as an administrator", "", MessageBoxButton.OK);
				result = false;
			}
		}
		return result;
	}
}
