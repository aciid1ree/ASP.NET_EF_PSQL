namespace ApplicationStore.Core.Validators;
using ApplicationStore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

public class ValidatorApp
{

    private static bool Check(string s) => string.IsNullOrEmpty(s);

    public static string ValidatorContractBase(Guid Id, Guid author, string activity, string name, string description, string outline, DateTime submitted)
    {
        var error = String.Empty;
     
        if (Guid.Empty == author)
        {
            error = "Введите поле author";
            if (Check(activity) && Check(name) && Check(description) && Check(outline)) error = "Введите еще одно поле author + еще одно поле";
        }
        else
        {
            if (Check(activity) && Check(name) && Check(description) && Check(outline)) error = "Введите еще одно поле помимо author";
        }
        return error;
    }
    public static string ValidatorContractPut(Guid Id, string activity, string name, string description, string outline)
    {
        var error = String.Empty;
        if (Guid.Empty == Id)
        {
            if (Check(activity) && Check(name) && Check(description) && Check(outline)) error = "Введите еще одно поле помимо id";
            else error = "Введите корректный id";
        }
        return error;
    }

}

