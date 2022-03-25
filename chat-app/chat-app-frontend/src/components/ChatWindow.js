import React from "react";
import Message from "./Message";
import jwtDecode from "jwt-decode";

// Chat Window should NOT update the channelMessages array
const ChatWindow = ({ channelMessages }) => {
  const token = localStorage.getItem("token");
  const usernameClaim = jwtDecode(token).sub; // grab username from the 'sub' claim

  // console.log("ChatWindow rendered");
  return (
    <div className="container inline-flex flex-col">
      {channelMessages.map((message, index) => {
        const messageAlignment =
          message.username === usernameClaim ? "self-end" : "self-start";
        return (
          <div key={index} className={messageAlignment}>
            <Message message={message} />
          </div>
        );
      })}
    </div>
  );
};

export default ChatWindow;
