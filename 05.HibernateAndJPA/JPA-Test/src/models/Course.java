package models;
import java.util.ArrayList;
import java.util.Date;

import javax.persistence.*;

@Entity
@Table(name="Courses")
public class Course {
	@Id
	private long id = System.currentTimeMillis();
	
	private String name;
	
	private String description;
	
	private Date startdate = new Date();;
	
	private Date enddate = new Date();;
	
	private double price;
	
	private List<Student> students = new ArrayList<>();
	
	public Course() {
		
	}
		
	public Course(String name) {
		this.name = name;
	}
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Date getStartdate() {
		return startdate;
	}

	public void setStartdate(Date startdate) {
		this.startdate = startdate;
	}

	public Date getEnddate() {
		return enddate;
	}

	public void setEnddate(Date enddate) {
		this.enddate = enddate;
	}

	public double getPrice() {
		return price;
	}

	public void setPrice(double price) {
		this.price = price;
	}
	
	
}
