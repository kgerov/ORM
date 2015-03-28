package models;

import java.util.Date;

import javax.persistence.*;

@Entity
@Table(name="Homeworks")
public class Homework {
	@Id
	private long id = System.currentTimeMillis();
	
	private String content;
	
	private Date submitiondate = new Date();
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "STUDENT_ID")
	private Student student;

	public Homework() {
		
	}
	
	public Homework(String con) {
		this.content = con;
	}
	
	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Date getSubmitiondate() {
		return submitiondate;
	}

	public void setSubmitiondate(Date submitiondate) {
		this.submitiondate = submitiondate;
	}
	
	public Student getStudent() {
		return student;
	}
}
