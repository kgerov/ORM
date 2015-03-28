package hellojpa;

import java.util.*;

import javax.persistence.*;

import models.Student;

/** 
 * A very simple, stand-alone program that stores a new entity in the
 * database and then performs a query to retrieve it.
 */
public class TestJPA {

    @SuppressWarnings("unchecked")
    public static void main(String[] args) {
        // Create a new EntityManagerFactory using the System properties.
        // The "hellojpa" name will be used to configure based on the
        // corresponding name in the META-INF/persistence.xml file
        EntityManagerFactory factory = Persistence.createEntityManagerFactory("hellojpa");
        try {
	        // Create a new EntityManager from the EntityManagerFactory. The
	        // EntityManager is the main object in the persistence API, and is
	        // used to create, delete, and query objects, as well as access
	        // the current transaction
	        EntityManager em = factory.createEntityManager();
	
	        // Begin a new local transaction so that we can persist a new entity
	        em.getTransaction().begin();
	        
	        // Create and persist a new Message entity	       
	        Student gosho = new Student("gosho");
	        em.persist(gosho);

	        // Commit the transaction, which will cause the entity to
	        // be stored in the database
	        em.getTransaction().commit();
	        
	        // Perform a simple query for all the Message entities
	        Query query = em.createQuery("select s from Student s");

	        // Go through each of the entities and print out each of their
	        // messages, as well as the date on which it was created 
	        for (Student s : (List<Student>) query.getResultList()) {
	            System.out.printf("%s (created on: %s)\n", s.getName(), s.getRegDate()); 
	        }	        
	
	        // It is always good practice to close the EntityManager so that
	        // resources are conserved.
	        em.close();
        } finally {
        		factory.close();
        }
    }
}
