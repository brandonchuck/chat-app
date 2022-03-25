import React from "react";

const Message = ({ message }) => {
  return (
    <div className="bg-blue-500 rounded-xl py-1 px-2 my-1 text-slate-100">
      <div className="text-left">{message.text}</div>
      <small className="text-right">{message.username}</small>
    </div>
  );
};

export default Message;
