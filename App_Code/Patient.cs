using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Patient
/// </summary>
public class Patient
{
    private string lastName;
    private string firstName;
    private string address;
	public Patient(string lastName, string firstName, string address)
	{
        this.lastName = lastName;
        this.firstName = firstName;
        this.address = address;
	}


}