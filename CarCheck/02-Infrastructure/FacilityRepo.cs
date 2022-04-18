using CarCheck;

public class FacilityRepo : IGenericRepo<ExaminationFacility>
{
    public int Add(ExaminationFacility obj)
    {
        if (Program.DataStoreS.facilities is null)
        {
            Program.DataStoreS.facilities = new List<ExaminationFacility> { obj };
        }
        else
            Program.DataStoreS.facilities.Add(obj);
        return obj.id;
    }

    public int Delete(ExaminationFacility obj)
    {
        Program.DataStoreS.facilities.Remove(obj);
        return obj.id;
    }

    public ExaminationFacility? Get(int id)
    {
        ExaminationFacility? facility = Program.DataStoreS.facilities.FirstOrDefault(facility => facility.id == id);
        if (facility == null)
        {
            return null;
        }
        else return facility;

    }

    public int Update(ExaminationFacility obj)
    {
        ExaminationFacility? facility = Program.DataStoreS.facilities.FirstOrDefault(facility => facility.id == obj.id);
        if (facility != null)
        {
            Program.DataStoreS.facilities.Remove(facility);
            Program.DataStoreS.facilities.Add(obj);
            return obj.id;
        }
        else
            return 0;
    }

    public List<ExaminationFacility> GetAll()
    {
        return Program.DataStoreS.facilities;
    }
}