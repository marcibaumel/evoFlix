import React, {useState, useEffect} from "react";

const FetchData = () => {
  const [users, setUsers] = useState(null);

  useEffect(() => {
    fetch("http://localhost:8000/users")
      .then(res  => {
        return res.json();
      })
      .then(data => {
        setUsers(data);
      });
  }, []);

  return (
    <div>
      <h1>All Users</h1>
      <div><pre>{users && JSON.stringify(users, null, 2) }</pre></div>
    </div>
  )
}

export default FetchData
