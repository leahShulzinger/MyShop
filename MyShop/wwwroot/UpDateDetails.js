

const getDataRfomForm = () => {

    const newUser =
    {
        email: document.querySelector("#email").value,
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        password: document.querySelector("#password").value
    }
    return newUser
}

const updateUserDetails =async () => {
    const newUser = getDataRfomForm();
    const userId =sessionStorage.getItem("User")
    alert(userId)
    alert(JSON.stringify(newUser))
    try {
        const responsePost = await fetch(`api/Users/${userId}`, {
            method: 'Put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newUser)

        });
        if (!responsePost.ok) {
            throw new Error(`HTTP error! status:${response.status}`)
        }

        const dataPost = await responsePost.json();
        sessionStorage.setItem("User", dataPost.userId);
       

    }
    catch (error) {
        console.log(error)
    }
}