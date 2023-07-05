import javax.persistence.*;

@Entity
@Table(name = "contributors")
public class Contributor {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;

    @Column(name = "first_name", nullable = false)
    private String firstName;

    @Column(name = "last_name", nullable = false)
    private String lastName;

    @ManyToOne
    @JoinColumn(name = "country_id", nullable = false)
    private Country country;

    @Column(name = "birth_date", nullable = false)
    private LocalDate birthDate;

    // Constructors, Getters and Setters

    public Contributor() {
        // Default constructor
    }

    public Contributor(String firstName, String lastName, Country country, LocalDate birthDate) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.country = country;
        this.birthDate = birthDate;
    }

    // Getters and Setters

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public Country getCountry() {
        return country;
    }

    public void setCountry(Country country) {
        this.country = country;
    }

    public LocalDate getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(LocalDate birthDate) {
        this.birthDate = birthDate;
    }
}
