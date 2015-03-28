package models;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.persistence.*;

@Entity
@Table(name="Students")
public class Student {
    @Id
    @Column(name = "STUDENT_ID")
    private long id = System.currentTimeMillis();

    //@Basic
    private String name;

    //@Basic
    private Date registrationdate = new Date();
    
    private Date birthday = new Date();
    
    private String phonenumber;
    
	@OneToMany(mappedBy = "student", fetch = FetchType.LAZY)
    private List<Homework> homeworks = new ArrayList<>();	

    public Student() {
    }

    public Student(String name) {
        this.name = name;
    }

    public void setId(long val) {
        id = val;
    }

    public long getId() {
        return id;
    }

    public void setName(String nameValue) {
        name = nameValue;
    }

    public String getName() {
        return name;
    }

    public void setRegDate(Date date) {
    	registrationdate = date;
    }

    public Date getRegDate() {
        return registrationdate;
    }

	public String getPhonenumber() {
		return phonenumber;
	}

	public void setPhonenumber(String phonenumber) {
		this.phonenumber = phonenumber;
	}

	public Date getBirthday() {
		return birthday;
	}

	public void setBirthday(Date birthday) {
		this.birthday = birthday;
	}
	
	public List<Homework> getHomeworks() {
		return homeworks;
	}
}
