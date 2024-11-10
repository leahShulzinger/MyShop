


const getDataRfomForm = () => { 
    const user = 
    {
        email: document.querySelector("#email").value,
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        password: document.querySelector("#password").value
    }
    return user;
}
const getEmailAndPasswordFromForm = () => {

    email=document.querySelector("#Email").value,
    password = document.querySelector("#Password").value
    return {email,password}
}


const createUser = async () => {
   
    const newUser = getDataRfomForm()
    try {
        const responsePost = await fetch("https://localhost:44376/api/Users", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)

        });
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }
        
         const dataPost = await responsePost.json();
        
        alert(`${dataPost} נרשמת בהצלחה `)      
    }
    catch (error) {
        alert(response)
    }
}

const chakepassword = async () => {
    const password = document.querySelector("#password").value;
    try {
        const responsePost = await fetch("https://localhost:44376/api/Users/chakepassword", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });
        const dataPost = await responsePost.json();

        alert(`${dataPost} `)



    }
    catch (error) {
        alert(response)
    }
}


const login = async () => {
    const {email,password} = getEmailAndPasswordFromForm()  
    try {
        const responsePost = await fetch(`api/Users/login?email=${email}&password=${password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                email: email,
                password: password
            }
        });
        
        if (!responsePost.ok) {
            console.log("llllllllllll")
            throw new Error(`HTTP error! status:${response.status}`)
        }
        if (responsePost.status == 204) {
            alert("user not found")
        }
        const dataPost = await responsePost.json();
        console.log(dataPost)
        sessionStorage.setItem("User",dataPost.userId)
       
        window.location.href = "UserDetails.html"
    }
    catch (error) {
        alert("קרתה תקלה, נסה שוב מאוחר יותר")
    }
}




